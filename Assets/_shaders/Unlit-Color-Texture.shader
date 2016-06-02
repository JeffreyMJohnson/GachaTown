Shader "Unlit/TextureColor" {
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Color("Color", Color) = (1, 1, 1, 1)
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 100
		Pass
		{
			Lighting Off
			SetTexture[_MainTex]
			{
				constantColor[_Color]
				combine constant * texture
			}
		}
	}
}