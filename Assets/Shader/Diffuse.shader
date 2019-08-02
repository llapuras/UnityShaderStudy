﻿Shader "Lapu/Diffuse" 
{
 //We define Properties in the properties block
    Properties 
    {
        _EmissiveColor ("Emissive Color", Color) = (1,1,1,1)
        _AmbientColor ("Ambient Color", Color) = (1,1,1,1)
        _MySliderValue ("This is a Slider", Range(0,10)) = 2.5
        _AttenValue ("Atten Slider", Range(0,10)) = 1
    }

    SubShader 
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf BasicDiffuse
        //We need to declare the properties variable type inside of the CGPROGRAM so we can access its value from the properties block.
        float4 _EmissiveColor;
        float4 _AmbientColor;
        float _MySliderValue;
        float _AttenValue;

        struct Input 
        {
            float2 uv_MainTex;
        };
        
        void surf (Input IN, inout SurfaceOutput o) 
        {
            //We can then use the properties values in our shader 
            float4 c;
            c = pow((_EmissiveColor + _AmbientColor), _MySliderValue);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
            
        }

        
        inline float4 LightingBasicDiffuse (SurfaceOutput s, fixed3 lightDir, fixed atten)
            {
                float difLight = max(0, dot (s.Normal, lightDir));
                float4 col;
                col.rgb = s.Albedo * _LightColor0.rgb * (difLight * atten * _AttenValue);
                col.a = s.Alpha;
                return col;
            }
        
        ENDCG
    } 
 
    FallBack "Diffuse"
}