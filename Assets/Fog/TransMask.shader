// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.25 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.25;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32998,y:32628,varname:node_3138,prsc:2|emission-1283-OUT,alpha-8993-OUT;n:type:ShaderForge.SFN_Tex2d,id:4575,x:32469,y:32943,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_4575,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6a985dfcd1d3ca94e9753748ed65c697,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5166,x:32341,y:32429,ptovrint:False,ptlb:ColorTex,ptin:_ColorTex,varname:node_5166,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:27897294b8894594195e7de6341b560e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1283,x:32764,y:32659,varname:node_1283,prsc:2|A-5166-RGB,B-7179-RGB;n:type:ShaderForge.SFN_Color,id:7179,x:32497,y:32709,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7179,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5367647,c2:1,c3:0.8083165,c4:1;n:type:ShaderForge.SFN_Multiply,id:8993,x:32745,y:32846,varname:node_8993,prsc:2|A-4522-OUT,B-4575-R;n:type:ShaderForge.SFN_Add,id:4522,x:32486,y:32567,varname:node_4522,prsc:2|A-5166-R,B-5205-OUT;n:type:ShaderForge.SFN_Slider,id:5205,x:32188,y:32664,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_5205,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2307692,max:1;proporder:4575-5166-7179-5205;pass:END;sub:END;*/

Shader "Shader Forge/TransMask" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _ColorTex ("ColorTex", 2D) = "white" {}
        _Color ("Color", Color) = (0.5367647,1,0.8083165,1)
        _Opacity ("Opacity", Range(0, 1)) = 0.2307692
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 2.0
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _ColorTex; uniform float4 _ColorTex_ST;
            uniform float4 _Color;
            uniform float _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _ColorTex_var = tex2D(_ColorTex,TRANSFORM_TEX(i.uv0, _ColorTex));
                float3 emissive = (_ColorTex_var.rgb*_Color.rgb);
                float3 finalColor = emissive;
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                return fixed4(finalColor,((_ColorTex_var.r+_Opacity)*_Texture_var.r));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
