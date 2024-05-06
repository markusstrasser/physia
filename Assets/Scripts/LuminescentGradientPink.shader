Shader "Custom/LuminescentGradientPink" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _ColorTop ("Top Color", Color) = (1,0.5,0.5,1)
        _ColorBottom ("Bottom Color", Color) = (1,0.75,0.75,1)
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _ColorTop;
            float4 _ColorBottom;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 gradient = lerp(_ColorTop, _ColorBottom, i.uv.y);
                return col * gradient;
            }
            ENDCG
        }
    }
}