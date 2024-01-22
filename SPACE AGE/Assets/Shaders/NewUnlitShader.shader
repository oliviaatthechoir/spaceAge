Shader "Unlit/WorldSpaceNormals"
{
    Properties
    {
        _DarkColor ("Dark Color", Color) = (0.3, 0.2, 0.1, 1.0)
        _LightColor ("Light Color", Color) = (0.9, 0.8, 0.7, 1.0)
    }

    SubShader
    {
        Tags{"Queue" = "Overlay" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma exclude_renderers gles xbox360 ps3
            ENDCG
        }

        Pass
        {
            CGPROGRAM
            #pragma exclude_renderers gles xbox360 ps3

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float3 worldNormal : TEXCOORD0;
            };

            // vertex shader: takes object space normal as input too
            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 _DarkColor;
            fixed4 _LightColor;

           fixed4 frag(v2f i) : COLOR
           {
                return fixed4(1.0, 0.0, 0.0, 1.0); // Red color
           }

            ENDCG
        }
    }
}
