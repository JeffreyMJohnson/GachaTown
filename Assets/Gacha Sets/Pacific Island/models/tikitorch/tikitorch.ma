//Maya ASCII 2016 scene
//Name: tikitorch.ma
//Last modified: Thu, Mar 24, 2016 05:56:48 PM
//Codeset: 1252
requires maya "2016";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2016";
fileInfo "version" "2016";
fileInfo "cutIdentifier" "201507301600-967122";
fileInfo "osv" "Microsoft Windows 7 Enterprise Edition, 64-bit Windows 7 Service Pack 1 (Build 7601)\n";
fileInfo "license" "education";
createNode transform -s -n "persp";
	rename -uid "2650D4B6-4B35-8C49-AA6D-71BB40677A2F";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -18.048775404841493 28.612179644429482 -10.147338413023919 ;
	setAttr ".r" -type "double3" -26.738352729132302 -482.19999999998538 0 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "B2C9B240-4475-C427-1F24-06A5D30C34BB";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 23.885170226593878;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	rename -uid "AF314669-4BF9-9DC7-38DE-39BF53B2D7A1";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 100.1 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "174EC53A-4A91-F99A-490A-E08848F0D186";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	rename -uid "A17A9E36-42F6-F4CC-516C-3E92A11815EC";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -0.20085879505934501 21.683360106569225 100.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "A5CE7858-4F0F-B340-C0B5-48940561277E";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 36.791415819927543;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	rename -uid "CA7C59EE-405F-BFB8-F132-D2B465EF495D";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 100.1 19.370860294612857 -1.91315369395979 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "1B8DB9BF-4FC8-C197-DCE5-8492561D7D7B";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 16.873712357017663;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".dsa" yes;
	setAttr ".o" yes;
createNode transform -n "tikitorch";
	rename -uid "3AD2085A-4B0E-2232-5C47-CFB379F80CF7";
	setAttr ".t" -type "double3" 0 9.7716925608197904 0 ;
	setAttr ".s" -type "double3" 1 8.0310560353267899 1 ;
createNode mesh -n "tikitorchShape" -p "tikitorch";
	rename -uid "22687F6A-4F65-E66B-2F34-6BA87B61E2E7";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.82589825987815857 0.46165850758552551 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "flame";
	rename -uid "2276984E-4E60-3BFA-B2A3-46B2ADDA7B70";
	setAttr ".t" -type "double3" 0 22.24470479072 0 ;
	setAttr ".s" -type "double3" 0.79289293149881634 0.79289293149881634 0.79289293149881634 ;
	setAttr ".spt" -type "double3" -0.029235483019042274 -0.074603420037824525 -0.032012215199183666 ;
createNode mesh -n "flameShape" -p "flame";
	rename -uid "0DFC70B9-49DC-658B-2B5C-A8BCDB987C09";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 74 ".pt[0:73]" -type "float3"  -0.083498098 0.24806236 0.013519496 
		-0.041535832 0.24806236 0.037746429 0.0061819293 0.24806236 0.029332578 0.037327476 
		0.24806236 -0.0077852607 0.037327439 0.24806236 -0.056239128 0.0061817914 0.24806236 
		-0.093356937 -0.041535743 0.24806236 -0.10177086 -0.083498053 0.24806236 -0.077543974 
		-0.10007027 0.24806236 -0.032012209 -0.13121583 0.21209858 0.057933092 -0.052352533 
		0.21209858 0.10346481 0.037327424 0.21209858 0.087651819 0.095861852 0.21209858 0.017893165 
		0.095862135 0.21209858 -0.073170215 0.037327483 0.21209858 -0.14292893 -0.052352577 
		0.21209858 -0.15874194 -0.13121587 0.21209858 -0.11321023 -0.16236126 0.21209858 
		-0.027638555 -0.16089074 0.15699889 0.10492322 -0.054686338 0.15699889 0.16626796 
		0.066187054 0.15699889 0.14496323 0.14510784 0.15699889 0.050977618 0.14521256 0.15699889 
		-0.071711838 0.06642732 0.15699889 -0.1656974 -0.054384649 0.15699889 -0.18700218 
		-0.16065067 0.15699889 -0.12565747 -0.2027564 0.15699889 -0.010367095 -0.15136045 
		0.089378171 0.13106713 -0.030594319 0.089378171 0.20080659 0.10676512 0.089378171 
		0.17658636 0.19637135 0.089378171 0.069739372 0.19637123 0.089378171 -0.069739461 
		0.10676512 0.089378171 -0.17658645 -0.03059426 0.089378171 -0.20080668 -0.15136045 
		0.089378171 -0.13106728 -0.19906476 0.089378171 -8.9406967e-008 -0.11602408 0.0096944058 
		0.12012872 -0.0053128004 0.0096944058 0.18404791 0.12058344 0.0096944058 0.16184905 
		0.20275643 0.0096944058 0.063919157 0.20275643 0.0096944058 -0.063919246 0.12058344 
		0.0096944058 -0.16184914 -0.0053127408 0.0096944058 -0.18404806 -0.11602414 0.0096944058 
		-0.12012884 -0.15974736 0.0096944058 -8.9406967e-008 -0.067825228 -0.11783471 0.059055969 
		0.0047183335 -0.11783471 0.10093904 0.087211773 -0.11783471 0.086393207 0.14105554 
		-0.11783471 0.02222468 0.14105555 -0.11783471 -0.061541378 0.087211832 -0.11783471 
		-0.12570991 0.0047183633 -0.11783471 -0.14025575 -0.067825213 -0.11783471 -0.098372713 
		-0.096474871 -0.11783471 -0.019658349 -0.028838508 -0.22047193 -0.036889385 0.013086812 
		-0.22047193 -0.015675023 0.060762502 -0.22047193 -0.023055077 0.091880634 -0.22047193 
		-0.056694292 0.091880597 -0.22047193 -0.1036703 0.060762472 -0.22047193 -0.13941158 
		0.013086803 -0.22047193 -0.14716119 -0.028838508 -0.22047193 -0.12460499 -0.045396078 
		-0.22047193 -0.079720348 -0.0034707282 -0.2529614 -0.065215483 0.018837154 -0.2529614 
		-0.053432524 0.044204891 -0.2529614 -0.05746346 0.060762633 -0.2529614 -0.075991444 
		0.060762648 -0.2529614 -0.10030285 0.04420501 -0.2529614 -0.11969607 0.018837297 
		-0.2529614 -0.12364869 -0.0034707803 -0.2529614 -0.11147593 -0.012280902 -0.2529614 
		-0.087963223 -0.029235501 0.26055244 -0.032012209 0.025376281 -0.26055244 -0.08971341;
createNode lightLinker -s -n "lightLinker1";
	rename -uid "F9014D21-431C-3F44-2B71-2582223DCFB6";
	setAttr -s 4 ".lnk";
	setAttr -s 4 ".slnk";
createNode displayLayerManager -n "layerManager";
	rename -uid "A3695CDF-4B38-C801-FB5C-4CBA47711FA0";
	setAttr ".cdl" 1;
	setAttr -s 2 ".dli[1:2]"  1 2;
	setAttr -s 3 ".dli";
createNode displayLayer -n "defaultLayer";
	rename -uid "CE888483-42D1-208D-586C-E5AF376EF066";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "6F172D0C-427F-35FA-657F-1FB0AE654F4C";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "4B0FFFA6-45CC-DF33-BA52-389A5E2787D6";
	setAttr ".g" yes;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "0A3CB6E8-44AC-BB8A-64F8-E4AE481F4DC8";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"top\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n"
		+ "                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n"
		+ "                -rendererName \"vp2Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n"
		+ "                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 656\n                -height 375\n                -sceneRenderFilter 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n"
		+ "            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n"
		+ "            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 656\n            -height 375\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"side\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n"
		+ "                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -rendererName \"vp2Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n"
		+ "                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n"
		+ "                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 655\n                -height 374\n                -sceneRenderFilter 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n"
		+ "            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n"
		+ "            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n"
		+ "            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 655\n            -height 374\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"front\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n"
		+ "                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -rendererName \"vp2Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n"
		+ "                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n"
		+ "                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 656\n                -height 374\n                -sceneRenderFilter 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n"
		+ "            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n"
		+ "            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n"
		+ "            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 656\n            -height 374\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels `;\n"
		+ "\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n"
		+ "                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -rendererName \"vp2Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n"
		+ "                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n"
		+ "                -width 655\n                -height 375\n                -sceneRenderFilter 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n"
		+ "            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n"
		+ "            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 655\n            -height 375\n"
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `outlinerPanel -unParent -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            outlinerEditor -e \n                -docTag \"isolOutln_fromSeln\" \n                -showShapes 0\n                -showReferenceNodes 1\n                -showReferenceMembers 1\n                -showAttributes 0\n                -showConnected 0\n                -showAnimCurvesOnly 0\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 1\n                -showAssets 1\n                -showContainedOnly 1\n                -showPublishedAsConnected 0\n"
		+ "                -showContainerContents 1\n                -ignoreDagHierarchy 0\n                -expandConnections 0\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 0\n                -highlightActive 1\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"defaultSetFilter\" \n                -showSetMembers 1\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n"
		+ "                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 0\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -docTag \"isolOutln_fromSeln\" \n            -showShapes 0\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n"
		+ "            -showPublishedAsConnected 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n"
		+ "            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"graphEditor\" -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n"
		+ "                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n"
		+ "                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n"
		+ "                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n"
		+ "                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n"
		+ "                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n"
		+ "                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dopeSheetPanel\" -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n"
		+ "                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n"
		+ "                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n"
		+ "                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n"
		+ "                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n"
		+ "                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"clipEditorPanel\" -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 0 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n"
		+ "                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"sequenceEditorPanel\" -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 1 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"hyperGraphPanel\" -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n"
		+ "                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n"
		+ "                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n"
		+ "                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"visorPanel\" -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n"
		+ "\t\t\t$panelName = `scriptedPanel -unParent  -type \"createNodePanel\" -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"polyTexturePlacementPanel\" -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\tif ($useSceneConfig) {\n\t\tscriptedPanel -e -to $panelName;\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"renderWindowPanel\" -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\tif ($useSceneConfig) {\n\t\tscriptedPanel -e -to $panelName;\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"blendShapePanel\" (localizedPanelLabel(\"Blend Shape\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\tblendShapePanel -unParent -l (localizedPanelLabel(\"Blend Shape\")) -mbv $menusOkayInPanels ;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tblendShapePanel -edit -l (localizedPanelLabel(\"Blend Shape\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dynRelEdPanel\" -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"relationshipPanel\" -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"referenceEditorPanel\" -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"componentEditorPanel\" -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dynPaintScriptedPanelType\" -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"scriptEditorPanel\" -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"profilerPanel\" -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"hyperShadePanel\" -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"nodeEditorPanel\" -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n"
		+ "                -extendToShapes 1\n                -activeTab -1\n                -editorMode \"default\" \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n"
		+ "                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -activeTab -1\n                -editorMode \"default\" \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-defaultImage \"\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"quad\\\" -ps 1 50 50 -ps 2 50 50 -ps 3 50 50 -ps 4 50 50 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Top View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Top View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera top` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 656\\n    -height 375\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Top View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera top` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 656\\n    -height 375\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 655\\n    -height 375\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 655\\n    -height 375\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Side View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Side View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera side` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 655\\n    -height 374\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Side View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera side` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 655\\n    -height 374\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Front View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Front View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera front` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 656\\n    -height 374\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Front View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera front` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 656\\n    -height 374\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        setFocus `paneLayout -q -p1 $gMainPane`;\n        sceneUIReplacement -deleteRemaining;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "23B24EFA-489B-B618-96A9-4DB966B7ECEC";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
createNode polyCylinder -n "polyCylinder1";
	rename -uid "B75DD1A7-458D-F963-B007-0AA0E1C6531F";
	setAttr ".sa" 12;
	setAttr ".sh" 9;
	setAttr ".sc" 1;
	setAttr ".cuv" 3;
createNode polyExtrudeFace -n "polyExtrudeFace1";
	rename -uid "5D847EEC-4509-4134-6931-32ACF47203E4";
	setAttr ".ics" -type "componentList" 2 "f[96:107]" "f[120:131]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 8.0310560353267899 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 6.9458098 0 ;
	setAttr ".rs" 36406;
	setAttr ".ls" -type "double3" 3.2833332546993583 3.2833332546993583 3.2833332546993583 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -1 5.8605638733268197 -1 ;
	setAttr ".cbx" -type "double3" 1 8.0310560353267899 1 ;
createNode polyTweak -n "polyTweak1";
	rename -uid "0D1B1962-48EA-44E4-D130-73BB88995DA0";
	setAttr ".uopa" yes;
	setAttr -s 109 ".tk";
	setAttr ".tk[0]" -type "float3" -0.046804421 0.048040092 0.027022548 ;
	setAttr ".tk[1]" -type "float3" -0.027022548 0.048040092 0.046804421 ;
	setAttr ".tk[2]" -type "float3" 0 0.048040092 0.054045096 ;
	setAttr ".tk[3]" -type "float3" 0.027022548 0.048040092 0.046804421 ;
	setAttr ".tk[4]" -type "float3" 0.046804421 0.048040092 0.027022548 ;
	setAttr ".tk[5]" -type "float3" 0.054045096 0.048040092 0 ;
	setAttr ".tk[6]" -type "float3" 0.046804421 0.048040092 -0.027022548 ;
	setAttr ".tk[7]" -type "float3" 0.027022548 0.048040092 -0.046804421 ;
	setAttr ".tk[8]" -type "float3" 0 0.048040092 -0.054045096 ;
	setAttr ".tk[9]" -type "float3" -0.027022548 0.048040092 -0.046804421 ;
	setAttr ".tk[10]" -type "float3" -0.046804421 0.048040092 -0.027022548 ;
	setAttr ".tk[11]" -type "float3" -0.054045096 0.048040092 0 ;
	setAttr ".tk[12]" -type "float3" -0.17784013 0.13690139 0.10267606 ;
	setAttr ".tk[13]" -type "float3" -0.10267606 0.13690139 0.17784013 ;
	setAttr ".tk[14]" -type "float3" 0 0.13690139 0.20535213 ;
	setAttr ".tk[15]" -type "float3" 0.10267606 0.13690139 0.17784013 ;
	setAttr ".tk[16]" -type "float3" 0.17784013 0.13690139 0.10267606 ;
	setAttr ".tk[17]" -type "float3" 0.20535213 0.13690139 0 ;
	setAttr ".tk[18]" -type "float3" 0.17784013 0.13690139 -0.10267606 ;
	setAttr ".tk[19]" -type "float3" 0.10267606 0.13690139 -0.17784013 ;
	setAttr ".tk[20]" -type "float3" 0 0.13690139 -0.20535213 ;
	setAttr ".tk[21]" -type "float3" -0.10267606 0.13690139 -0.17784013 ;
	setAttr ".tk[22]" -type "float3" -0.17784013 0.13690139 -0.10267606 ;
	setAttr ".tk[23]" -type "float3" -0.20535213 0.13690139 0 ;
	setAttr ".tk[24]" -type "float3" -0.24795245 0.12724926 0.14315541 ;
	setAttr ".tk[25]" -type "float3" -0.14315541 0.12724926 0.24795245 ;
	setAttr ".tk[26]" -type "float3" 0 0.12724926 0.28631082 ;
	setAttr ".tk[27]" -type "float3" 0.14315541 0.12724926 0.24795245 ;
	setAttr ".tk[28]" -type "float3" 0.24795245 0.12724926 0.14315541 ;
	setAttr ".tk[29]" -type "float3" 0.28631082 0.12724926 0 ;
	setAttr ".tk[30]" -type "float3" 0.24795245 0.12724926 -0.14315541 ;
	setAttr ".tk[31]" -type "float3" 0.14315541 0.12724926 -0.24795245 ;
	setAttr ".tk[32]" -type "float3" 0 0.12724926 -0.28631082 ;
	setAttr ".tk[33]" -type "float3" -0.14315541 0.12724926 -0.24795245 ;
	setAttr ".tk[34]" -type "float3" -0.24795245 0.12724926 -0.14315541 ;
	setAttr ".tk[35]" -type "float3" -0.28631082 0.12724926 0 ;
	setAttr ".tk[36]" -type "float3" -0.24795245 0.063624628 0.14315541 ;
	setAttr ".tk[37]" -type "float3" -0.14315541 0.063624628 0.24795245 ;
	setAttr ".tk[38]" -type "float3" 0 0.063624628 0.28631082 ;
	setAttr ".tk[39]" -type "float3" 0.14315541 0.063624628 0.24795245 ;
	setAttr ".tk[40]" -type "float3" 0.24795245 0.063624628 0.14315541 ;
	setAttr ".tk[41]" -type "float3" 0.28631082 0.063624628 0 ;
	setAttr ".tk[42]" -type "float3" 0.24795245 0.063624628 -0.14315541 ;
	setAttr ".tk[43]" -type "float3" 0.14315541 0.063624628 -0.24795245 ;
	setAttr ".tk[44]" -type "float3" 0 0.063624628 -0.28631082 ;
	setAttr ".tk[45]" -type "float3" -0.14315541 0.063624628 -0.24795245 ;
	setAttr ".tk[46]" -type "float3" -0.24795245 0.063624628 -0.14315541 ;
	setAttr ".tk[47]" -type "float3" -0.28631082 0.063624628 0 ;
	setAttr ".tk[48]" -type "float3" -0.24795245 3.5483909e-009 0.14315541 ;
	setAttr ".tk[49]" -type "float3" -0.14315541 3.5483909e-009 0.24795245 ;
	setAttr ".tk[50]" -type "float3" 0 3.5483909e-009 0.28631082 ;
	setAttr ".tk[51]" -type "float3" 0.14315541 3.5483909e-009 0.24795245 ;
	setAttr ".tk[52]" -type "float3" 0.24795245 3.5483909e-009 0.14315541 ;
	setAttr ".tk[53]" -type "float3" 0.28631082 3.5483909e-009 0 ;
	setAttr ".tk[54]" -type "float3" 0.24795245 3.5483909e-009 -0.14315541 ;
	setAttr ".tk[55]" -type "float3" 0.14315541 3.5483909e-009 -0.24795245 ;
	setAttr ".tk[56]" -type "float3" 0 3.5483909e-009 -0.28631082 ;
	setAttr ".tk[57]" -type "float3" -0.14315541 3.5483909e-009 -0.24795245 ;
	setAttr ".tk[58]" -type "float3" -0.24795245 3.5483909e-009 -0.14315541 ;
	setAttr ".tk[59]" -type "float3" -0.28631082 3.5483909e-009 0 ;
	setAttr ".tk[60]" -type "float3" -0.24795245 -0.063624628 0.14315541 ;
	setAttr ".tk[61]" -type "float3" -0.14315541 -0.063624628 0.24795245 ;
	setAttr ".tk[62]" -type "float3" 0 -0.063624628 0.28631082 ;
	setAttr ".tk[63]" -type "float3" 0.14315541 -0.063624628 0.24795245 ;
	setAttr ".tk[64]" -type "float3" 0.24795245 -0.063624628 0.14315541 ;
	setAttr ".tk[65]" -type "float3" 0.28631082 -0.063624628 0 ;
	setAttr ".tk[66]" -type "float3" 0.24795245 -0.063624628 -0.14315541 ;
	setAttr ".tk[67]" -type "float3" 0.14315541 -0.063624628 -0.24795245 ;
	setAttr ".tk[68]" -type "float3" 0 -0.063624628 -0.28631082 ;
	setAttr ".tk[69]" -type "float3" -0.14315541 -0.063624628 -0.24795245 ;
	setAttr ".tk[70]" -type "float3" -0.24795245 -0.063624628 -0.14315541 ;
	setAttr ".tk[71]" -type "float3" -0.28631082 -0.063624628 0 ;
	setAttr ".tk[72]" -type "float3" -0.24795245 -0.12724926 0.14315541 ;
	setAttr ".tk[73]" -type "float3" -0.14315541 -0.12724926 0.24795245 ;
	setAttr ".tk[74]" -type "float3" 0 -0.12724926 0.28631082 ;
	setAttr ".tk[75]" -type "float3" 0.14315541 -0.12724926 0.24795245 ;
	setAttr ".tk[76]" -type "float3" 0.24795245 -0.12724926 0.14315541 ;
	setAttr ".tk[77]" -type "float3" 0.28631082 -0.12724926 0 ;
	setAttr ".tk[78]" -type "float3" 0.24795245 -0.12724926 -0.14315541 ;
	setAttr ".tk[79]" -type "float3" 0.14315541 -0.12724926 -0.24795245 ;
	setAttr ".tk[80]" -type "float3" 0 -0.12724926 -0.28631082 ;
	setAttr ".tk[81]" -type "float3" -0.14315541 -0.12724926 -0.24795245 ;
	setAttr ".tk[82]" -type "float3" -0.24795245 -0.12724926 -0.14315541 ;
	setAttr ".tk[83]" -type "float3" -0.28631082 -0.12724926 0 ;
	setAttr ".tk[84]" -type "float3" -0.17784013 -0.13690139 0.10267606 ;
	setAttr ".tk[85]" -type "float3" -0.10267606 -0.13690139 0.17784013 ;
	setAttr ".tk[86]" -type "float3" 0 -0.13690139 0.20535213 ;
	setAttr ".tk[87]" -type "float3" 0.10267606 -0.13690139 0.17784013 ;
	setAttr ".tk[88]" -type "float3" 0.17784013 -0.13690139 0.10267606 ;
	setAttr ".tk[89]" -type "float3" 0.20535213 -0.13690139 0 ;
	setAttr ".tk[90]" -type "float3" 0.17784013 -0.13690139 -0.10267606 ;
	setAttr ".tk[91]" -type "float3" 0.10267606 -0.13690139 -0.17784013 ;
	setAttr ".tk[92]" -type "float3" 0 -0.13690139 -0.20535213 ;
	setAttr ".tk[93]" -type "float3" -0.10267606 -0.13690139 -0.17784013 ;
	setAttr ".tk[94]" -type "float3" -0.17784013 -0.13690139 -0.10267606 ;
	setAttr ".tk[95]" -type "float3" -0.20535213 -0.13690139 0 ;
	setAttr ".tk[96]" -type "float3" -0.046804421 -0.048040092 0.027022548 ;
	setAttr ".tk[97]" -type "float3" -0.027022548 -0.048040092 0.046804421 ;
	setAttr ".tk[98]" -type "float3" 0 -0.048040092 0.054045096 ;
	setAttr ".tk[99]" -type "float3" 0.027022548 -0.048040092 0.046804421 ;
	setAttr ".tk[100]" -type "float3" 0.046804421 -0.048040092 0.027022548 ;
	setAttr ".tk[101]" -type "float3" 0.054045096 -0.048040092 0 ;
	setAttr ".tk[102]" -type "float3" 0.046804421 -0.048040092 -0.027022548 ;
	setAttr ".tk[103]" -type "float3" 0.027022548 -0.048040092 -0.046804421 ;
	setAttr ".tk[104]" -type "float3" 0 -0.048040092 -0.054045096 ;
	setAttr ".tk[105]" -type "float3" -0.027022548 -0.048040092 -0.046804421 ;
	setAttr ".tk[106]" -type "float3" -0.046804421 -0.048040092 -0.027022548 ;
	setAttr ".tk[107]" -type "float3" -0.054045096 -0.048040092 0 ;
	setAttr ".tk[120]" -type "float3" 0 0.039745942 0 ;
createNode polyExtrudeFace -n "polyExtrudeFace2";
	rename -uid "BE0212F0-4315-3FE2-3A15-ADB7948E28E7";
	setAttr ".ics" -type "componentList" 1 "f[120:131]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 8.0310560353267899 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 11.330131 0 ;
	setAttr ".rs" 55947;
	setAttr ".ls" -type "double3" 0.66666666235739014 0.66666666235739014 0.66666666235739014 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -1.1398806571960449 11.330130403577453 -1.1398806571960449 ;
	setAttr ".cbx" -type "double3" 1.1398806571960449 11.330130403577453 1.1398806571960449 ;
createNode polyTweak -n "polyTweak2";
	rename -uid "B7746700-4C1D-8784-DF57-7183B610D4F7";
	setAttr ".uopa" yes;
	setAttr -s 25 ".tk[109:133]" -type "float3"  0.1251104 0.32959899 -0.072232537
		 0.07223253 0.32959899 -0.12511039 0.069940351 0.41078952 -0.12114024 0.12114024 0.41078952
		 -0.069940351 0 0.32959899 -0.14446507 0 0.41078952 -0.1398807 -0.072232522 0.32959899
		 -0.1251104 -0.069940351 0.41078952 -0.12114024 -0.12511036 0.32959899 -0.072232537
		 -0.12114024 0.41078952 -0.069940351 -0.14446506 0.32959899 4.1687698e-009 -0.1398807
		 0.41078952 0 -0.1251104 0.32959899 0.072232537 -0.12114024 0.41078952 0.069940351
		 -0.07223253 0.32959899 0.12511039 -0.069940351 0.41078952 0.12114024 0 0.32959899
		 0.14446507 0 0.41078952 0.1398807 0.072232522 0.32959899 0.1251104 0.069940351 0.41078952
		 0.12114024 0.12511036 0.32959899 0.072232537 0.12114024 0.41078952 0.069940351 0.14446506
		 0.32959899 -4.1687698e-009 0.1398807 0.41078952 0 0 0.41078952 0;
createNode polyExtrudeFace -n "polyExtrudeFace3";
	rename -uid "745031BA-4E8C-6126-7FCD-14BF1042A2A4";
	setAttr ".ics" -type "componentList" 1 "f[120:131]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 8.0310560353267899 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 11.330131 0 ;
	setAttr ".rs" 53069;
	setAttr ".lt" -type "double3" 0 -2.2917732880885711e-018 0.48967877067374666 ;
	setAttr ".ls" -type "double3" 0.79999999741443395 0.79999999741443395 0.79999999741443395 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.97361850738525391 11.330130403577453 -0.97361850738525391 ;
	setAttr ".cbx" -type "double3" 0.97361850738525391 11.330130403577453 0.97361850738525391 ;
createNode polySplitRing -n "polySplitRing1";
	rename -uid "495F7E61-4578-E193-281D-5A99F4C88D09";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 12 "e[219]" "e[221]" "e[224]" "e[228]" "e[232]" "e[236]" "e[240]" "e[244]" "e[248]" "e[252]" "e[256]" "e[260]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 8.0310560353267899 0 0 0 0 1 0 0 0 0 1;
	setAttr ".wt" 0.81844359636306763;
	setAttr ".dr" no;
	setAttr ".re" 256;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing2";
	rename -uid "BEA9AE54-4384-DD3A-7259-1385D8F37887";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 12 "e[219]" "e[221]" "e[224]" "e[228]" "e[232]" "e[236]" "e[240]" "e[244]" "e[248]" "e[252]" "e[256]" "e[260]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 8.0310560353267899 0 0 0 0 1 0 0 0 0 1;
	setAttr ".wt" 0.24893900752067566;
	setAttr ".dr" no;
	setAttr ".re" 260;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing3";
	rename -uid "3928910B-4BD7-ADC2-EA20-35B485BB97B3";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 11 "e[348:349]" "e[351]" "e[353]" "e[355]" "e[357]" "e[359]" "e[361]" "e[363]" "e[365]" "e[367]" "e[369]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 8.0310560353267899 0 0 0 0 1 0 0 0 0 1;
	setAttr ".wt" 0.50482380390167236;
	setAttr ".re" 348;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySoftEdge -n "polySoftEdge1";
	rename -uid "05CCF677-4B69-F385-6EBE-E58615AA2248";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 8.0310560353267899 0 0 0 0 1 0 0 9.7716925608197904 0 1;
	setAttr ".a" 180;
createNode polyTweak -n "polyTweak3";
	rename -uid "00DE66A4-4F9B-8A1E-3BD1-43A22EFF06A4";
	setAttr ".uopa" yes;
	setAttr -s 194 ".tk";
	setAttr ".tk[0:165]" -type "float3"  0.33612114 -0.1295168 -0.19405963 0.19405963
		 -0.1295168 -0.33612114 0 -0.1295168 -0.38811925 -0.19405963 -0.1295168 -0.33612114
		 -0.33612114 -0.1295168 -0.19405963 -0.38811925 -0.1295168 0 -0.33612114 -0.1295168
		 0.19405963 -0.19405963 -0.1295168 0.33612114 0 -0.1295168 0.38811925 0.19405963 -0.1295168
		 0.33612114 0.33612114 -0.1295168 0.19405963 0.38811925 -0.1295168 0 0.034737699 -0.24339803
		 -0.020055832 0.020055832 -0.24339803 -0.034737699 0 -0.24339803 -0.040111665 -0.020055832
		 -0.24339803 -0.034737699 -0.034737699 -0.24339803 -0.020055832 -0.040111665 -0.24339803
		 0 -0.034737699 -0.24339803 0.020055832 -0.020055832 -0.24339803 0.034737699 0 -0.24339803
		 0.040111665 0.020055832 -0.24339803 0.034737699 0.034737699 -0.24339803 0.020055832
		 0.040111665 -0.24339803 0 -0.19939309 -0.018044533 0.11511968 -0.11511968 -0.018044533
		 0.19939309 0 -0.018044533 0.23023936 0.11511968 -0.018044533 0.19939309 0.19939309
		 -0.018044533 0.11511968 0.23023936 -0.018044533 0 0.19939309 -0.018044533 -0.11511968
		 0.11511968 -0.018044533 -0.19939309 0 -0.018044533 -0.23023936 -0.11511968 -0.018044533
		 -0.19939309 -0.19939309 -0.018044533 -0.11511968 -0.23023936 -0.018044533 0 -0.24953769
		 -0.010406515 0.14407067 -0.14407067 -0.010406515 0.24953769 0 -0.010406515 0.28814134
		 0.14407067 -0.010406515 0.24953769 0.24953769 -0.010406515 0.14407067 0.28814134
		 -0.010406515 0 0.24953769 -0.010406515 -0.14407067 0.14407067 -0.010406515 -0.24953769
		 0 -0.010406515 -0.28814134 -0.14407067 -0.010406515 -0.24953769 -0.24953769 -0.010406515
		 -0.14407067 -0.28814134 -0.010406515 0 -0.27911395 -0.028912364 0.16114649 -0.16114649
		 -0.028912364 0.27911395 0 -0.028912364 0.32229298 0.16114649 -0.028912364 0.27911395
		 0.27911395 -0.028912364 0.16114649 0.32229298 -0.028912364 0 0.27911395 -0.028912364
		 -0.16114649 0.16114649 -0.028912364 -0.27911395 0 -0.028912364 -0.32229298 -0.16114649
		 -0.028912364 -0.27911395 -0.27911395 -0.028912364 -0.16114649 -0.32229298 -0.028912364
		 0 -0.28777301 -0.062286831 0.16614583 -0.16614583 -0.062286831 0.28777301 0 -0.062286831
		 0.33229166 0.16614583 -0.062286831 0.28777301 0.28777301 -0.062286831 0.16614583
		 0.33229166 -0.062286831 0 0.28777301 -0.062286831 -0.16614583 0.16614583 -0.062286831
		 -0.28777301 0 -0.062286831 -0.33229166 -0.16614583 -0.062286831 -0.28777301 -0.28777301
		 -0.062286831 -0.16614583 -0.33229166 -0.062286831 0 -0.27265123 -0.10796499 0.15741527
		 -0.15741527 -0.10796499 0.27265123 0 -0.10796499 0.31483054 0.15741527 -0.10796499
		 0.27265123 0.27265123 -0.10796499 0.15741527 0.31483054 -0.10796499 0 0.27265123
		 -0.10796499 -0.15741527 0.15741527 -0.10796499 -0.27265123 0 -0.10796499 -0.31483054
		 -0.15741527 -0.10796499 -0.27265123 -0.27265123 -0.10796499 -0.15741527 -0.31483054
		 -0.10796499 0 -0.31473005 -0.11545431 0.18170947 -0.18170947 -0.11545431 0.31473005
		 0 -0.11545431 0.36341894 0.18170947 -0.11545431 0.31473005 0.31473005 -0.11545431
		 0.18170947 0.36341894 -0.11545431 0 0.31473005 -0.11545431 -0.18170947 0.18170947
		 -0.11545431 -0.31473005 0 -0.11545431 -0.36341894 -0.18170947 -0.11545431 -0.31473005
		 -0.31473005 -0.11545431 -0.18170947 -0.36341894 -0.11545431 0 -0.23958902 -0.068908408
		 0.13832673 -0.13832673 -0.068908408 0.23958902 0 -0.068908408 0.27665347 0.13832673
		 -0.068908408 0.23958902 0.23958902 -0.068908408 0.13832673 0.27665347 -0.068908408
		 0 0.23958902 -0.068908408 -0.13832673 0.13832673 -0.068908408 -0.23958902 0 -0.068908408
		 -0.27665347 -0.13832673 -0.068908408 -0.23958902 -0.23958902 -0.068908408 -0.13832673
		 -0.27665347 -0.068908408 0 0 -0.13111249 0 -0.12329283 -0.060528509 0.07118316 -0.07118313
		 -0.060528472 0.12329289 -0.065668106 -0.075635232 0.11374052 -0.11374049 -0.075635232
		 0.065668076 0 -0.060528528 0.14236632 0 -0.075635232 0.13133615 0.071183115 -0.060528509
		 0.12329283 0.065668106 -0.075635232 0.11374052 0.12329283 -0.060528472 0.07118316
		 0.11374049 -0.075635232 0.065668076 0.14236626 -0.060528528 -4.1082062e-009 0.13133621
		 -0.075635232 0 0.12329283 -0.060528509 -0.07118316 0.11374049 -0.075635232 -0.065668076
		 0.07118313 -0.060528472 -0.12329289 0.065668106 -0.075635232 -0.11374052 0 -0.060528528
		 -0.14236632 0 -0.075635232 -0.13133615 -0.071183115 -0.060528509 -0.12329283 -0.065668106
		 -0.075635232 -0.11374052 -0.12329283 -0.060528472 -0.07118316 -0.11374049 -0.075635232
		 -0.065668076 -0.14236626 -0.060528528 4.1082062e-009 -0.13133621 -0.075635232 0 -0.38111055
		 -0.070828192 0.22003427 -0.22003427 -0.070828192 0.38111049 0 -0.070828192 0.44006854
		 0.22003427 -0.070828192 0.38111049 0.38111055 -0.070828192 0.22003427 0.44006854
		 -0.070828192 0 0.38111055 -0.070828192 -0.22003427 0.22003427 -0.070828192 -0.38111049
		 0 -0.070828192 -0.44006854 -0.22003427 -0.070828192 -0.38111049 -0.38111055 -0.070828192
		 -0.22003427 -0.44006854 -0.070828192 0 -0.24640387 -0.070358373 0.14226134 -0.14226136
		 -0.070358373 0.24640372 0 -0.070358388 -7.3396366e-019 0 -0.070358373 0.28452277
		 0.14226136 -0.070358373 0.24640372 0.24640387 -0.070358373 0.14226149 0.28452271
		 -0.070358373 0 0.24640387 -0.070358373 -0.14226134 0.14226136 -0.070358373 -0.24640372
		 0 -0.070358373 -0.28452277 -0.14226136 -0.070358373 -0.24640372 -0.24640387 -0.070358373
		 -0.14226149 -0.28452271 -0.070358373 0 -0.09187986 -0.029004743 -0.053046864 -0.05304689
		 -0.029004743 -0.091879822 0 -0.029004794 -0.10609373 0.05304689 -0.029004743 -0.091879822
		 0.091879852 -0.029004743 -0.053046864 0.10609378 -0.029004794 -5.706563e-010 0.09187986
		 -0.029004743 0.053046864 0.05304689 -0.029004743 0.091879822;
	setAttr ".tk[166:193]" 0 -0.029004794 0.10609373 -0.05304689 -0.029004743 0.091879822
		 -0.091879852 -0.029004743 0.053046864 -0.10609378 -0.029004794 5.706563e-010 -0.14752164
		 -0.091468818 3.4117078e-009 -0.12775759 -0.091468789 -0.073760837 -0.073760822 -0.091468789
		 -0.12775755 0 -0.091468818 -0.14752167 0.073760822 -0.091468789 -0.12775755 0.12775755
		 -0.091468789 -0.073760837 0.14752164 -0.091468818 -3.4117078e-009 0.12775759 -0.091468789
		 0.073760837 0.073760822 -0.091468789 0.12775755 0 -0.091468818 0.14752167 -0.073760822
		 -0.091468789 0.12775755 -0.12775755 -0.091468789 0.073760837 0.094485462 -0.027268171
		 -1.3469048e-009 0.081826799 -0.027268142 0.04724288 0.047242731 -0.027268142 0.081826925
		 0 -0.027268171 0.09448576 -0.047242731 -0.027268142 0.081826925 -0.081826806 -0.027268142
		 0.04724288 -0.094485462 -0.027268171 1.3469048e-009 -0.081826799 -0.027268142 -0.04724288
		 -0.047242731 -0.027268142 -0.081826925 0 -0.027268171 -0.09448576 0.047242731 -0.027268142
		 -0.081826925 0.081826806 -0.027268142 -0.04724288;
createNode polySoftEdge -n "polySoftEdge2";
	rename -uid "277BF8DE-4EC6-B2A6-23A5-4BBD0A8702B4";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[96:107]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 8.0310560353267899 0 0 0 0 1 0 0 9.7716925608197904 0 1;
	setAttr ".a" 0;
createNode polySoftEdge -n "polySoftEdge3";
	rename -uid "9361E73C-42C9-2C3F-83D6-3A8E639CC4BF";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[0:11]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 8.0310560353267899 0 0 0 0 1 0 0 9.7716925608197904 0 1;
	setAttr ".a" 0;
createNode polySoftEdge -n "polySoftEdge4";
	rename -uid "FDEAA870-44DD-A1DC-87BE-18A0A08A9DDC";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 11 "e[266]" "e[268]" "e[270]" "e[272]" "e[274]" "e[276]" "e[278]" "e[280]" "e[282]" "e[284]" "e[286:287]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 8.0310560353267899 0 0 0 0 1 0 0 9.7716925608197904 0 1;
	setAttr ".a" 0;
createNode rampShader -n "rampShader1";
	rename -uid "D3F795F5-4A0E-197F-CFBC-A5AA9C39CDB6";
	setAttr ".clr[0].clrp" 0;
	setAttr ".clr[0].clrc" -type "float3" 0.5 0.5 0.5 ;
	setAttr ".clr[0].clri" 1;
	setAttr ".it[0].itp" 0;
	setAttr ".it[0].itc" -type "float3" 0 0 0 ;
	setAttr ".it[0].iti" 1;
	setAttr ".ic[0].icp" 0;
	setAttr ".ic[0].icc" -type "float3" 0 0 0 ;
	setAttr ".ic[0].ici" 1;
	setAttr -s 2 ".sro[0:1]"  0 1 2 0.5 0.5 2;
	setAttr ".sc[0].scp" 0;
	setAttr ".sc[0].scc" -type "float3" 0.5 0.5 0.5 ;
	setAttr ".sc[0].sci" 1;
	setAttr ".rfl[0]"  0 1 1;
	setAttr ".env[0].envp" 0;
	setAttr ".env[0].envc" -type "float3" 0 0 0 ;
	setAttr ".env[0].envi" 1;
createNode shadingEngine -n "rampShader1SG";
	rename -uid "96798CAE-43EF-67AC-3A31-A08A71A0C304";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo1";
	rename -uid "F54103BD-4DBC-6DFB-9B92-3C8B5A11A99C";
createNode rampShader -n "rampShader2";
	rename -uid "02D01E1B-4FD1-A44C-D4E6-2E8FAEE8497B";
	setAttr ".clr[0].clrp" 0;
	setAttr ".clr[0].clrc" -type "float3" 1 0.4267 0 ;
	setAttr ".clr[0].clri" 1;
	setAttr ".it[0].itp" 0;
	setAttr ".it[0].itc" -type "float3" 0 0 0 ;
	setAttr ".it[0].iti" 1;
	setAttr ".ic[0].icp" 0;
	setAttr ".ic[0].icc" -type "float3" 0 0 0 ;
	setAttr ".ic[0].ici" 1;
	setAttr ".gi" 0.21481481194496155;
	setAttr -s 2 ".sro[0:1]"  0 1 2 0.5 0.5 2;
	setAttr ".sc[0].scp" 0;
	setAttr ".sc[0].scc" -type "float3" 0.5 0.5 0.5 ;
	setAttr ".sc[0].sci" 1;
	setAttr ".rfl[0]"  0 1 1;
	setAttr ".env[0].envp" 0;
	setAttr ".env[0].envc" -type "float3" 0 0 0 ;
	setAttr ".env[0].envi" 1;
createNode shadingEngine -n "rampShader2SG";
	rename -uid "1E418149-426A-618F-9592-E480E7EADCC0";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo2";
	rename -uid "1F095A07-44BF-DFEC-E37D-7E917F920D1A";
createNode displayLayer -n "layer1";
	rename -uid "96F519BC-4007-B506-E28A-0E907E18C140";
	setAttr ".do" 1;
createNode displayLayer -n "layer2";
	rename -uid "0966B1DB-4DB0-5DFB-6A17-B28665D8E336";
	setAttr ".do" 2;
createNode polySoftEdge -n "polySoftEdge5";
	rename -uid "CB957C0C-42D4-9232-1B77-B8BB1FEEDE7A";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 22.24470479072 0 1;
	setAttr ".a" 180;
createNode polyTweak -n "polyTweak4";
	rename -uid "4223BF1A-4F79-DD66-4745-BDA64243838B";
	setAttr ".uopa" yes;
	setAttr -s 74 ".tk[0:73]" -type "float3"  0 -0.61827338 1.8626451e-009
		 0 -0.61827338 -5.5879354e-009 0 -0.61827338 0 0 -0.61827338 0 0 -0.61827338 0 0 -0.61827338
		 -5.5879354e-009 0 -0.61827338 -5.5879354e-009 0 -0.61827338 0 0 -0.61827338 0 0 -0.61827338
		 -0.021117868 0 -0.61827338 -0.021117868 0 -0.61827338 -0.021117868 0 -0.61827338
		 -0.021117868 0 -0.61827338 -0.021117868 0 -0.61827338 -0.021117868 0 -0.61827338
		 -0.021117868 0 -0.61827338 -0.021117868 0 -0.61827338 -0.021117868 -0.027726896 -0.61827344
		 -0.10451189 -0.027495816 -0.61827344 -0.10451189 -0.027726896 -0.61827344 -0.10451189
		 -0.028002722 -0.61827344 -0.10451189 -0.028509498 -0.61827344 -0.10451189 -0.028886823
		 -0.61827344 -0.10451189 -0.028953986 -0.61827344 -0.10451189 -0.028886823 -0.61827344
		 -0.10451189 -0.028192731 -0.61827344 -0.10451189 -0.16473573 -0.61812395 -0.15439379
		 -0.1644485 -0.61812395 -0.15430093 -0.16426554 -0.61812395 -0.15433317 -0.16390878
		 -0.61812395 -0.15447548 -0.16390878 -0.61812395 -0.15466124 -0.16426554 -0.61812395
		 -0.15480354 -0.1644485 -0.61812395 -0.15483579 -0.16473573 -0.61812395 -0.15474293
		 -0.16479927 -0.61812395 -0.15456834 -0.3353551 -0.58067346 -0.10157856 -0.28651941
		 -0.58067346 -0.073383212 -0.23098554 -0.58067346 -0.083175421 -0.19473836 -0.58067346
		 -0.12637305 -0.19473836 -0.58067346 -0.18276367 -0.23098554 -0.58067346 -0.22596139
		 -0.28651941 -0.58067346 -0.23575354 -0.3353551 -0.58067346 -0.20755821 -0.35464185
		 -0.58067346 -0.15456837 -0.47708708 -0.29126111 0.11695486 -0.31432748 -0.29126111
		 0.21092428 -0.12924407 -0.29126111 0.1782891 -0.0084395111 -0.29126111 0.034319725
		 -0.0084395111 -0.29126111 -0.15361886 -0.12924407 -0.29126111 -0.29758826 -0.31432742
		 -0.29126111 -0.33022323 -0.47708702 -0.29126111 -0.2362541 -0.54136586 -0.29126111
		 -0.059649579 -0.49432081 -0.061729971 0.43672496 -0.31596887 -0.061729971 0.55413949
		 -0.11315446 -0.061729971 0.51342171 0.019223243 -0.061729971 0.33902186 0.019223243
		 -0.061729971 0.12614897 -0.1131544 -0.061729971 -0.038101152 -0.31596875 -0.061729971
		 -0.077034481 -0.49432075 -0.061729971 0.033900827 -0.56475747 -0.061729971 0.23035491
		 -0.38640553 -0.078505248 0.38016579 -0.29150641 -0.078505248 0.44025037 -0.18359116
		 -0.078505248 0.41908747 -0.1131544 -0.078505248 0.32932821 -0.1131544 -0.078505248
		 0.21275809 -0.18359116 -0.078505248 0.1271763 -0.29150635 -0.078505248 0.10563522
		 -0.38640547 -0.078505248 0.16383788 -0.42388409 -0.078505248 0.27015513 0 -0.61827338
		 0 -0.26368874 -0.10215998 0.27860546;
createNode polySphere -n "polySphere1";
	rename -uid "5068225D-4064-3C13-B7D1-B5B000C0959B";
	setAttr ".sa" 9;
	setAttr ".sh" 9;
createNode polyMapCut -n "polyMapCut1";
	rename -uid "B8EB3F59-41F8-194E-103B-6887EF0AE2EC";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[0:11]";
createNode polyTweakUV -n "polyTweakUV1";
	rename -uid "58FAF535-43A0-4500-E348-BD8F315D3137";
	setAttr ".uopa" yes;
	setAttr -s 13 ".uvtk";
	setAttr ".uvtk[0]" -type "float2" -0.32159624 0 ;
	setAttr ".uvtk[1]" -type "float2" -0.32159624 0 ;
	setAttr ".uvtk[2]" -type "float2" -0.32159624 0 ;
	setAttr ".uvtk[3]" -type "float2" -0.32159624 0 ;
	setAttr ".uvtk[4]" -type "float2" -0.32159624 0 ;
	setAttr ".uvtk[5]" -type "float2" -0.32159624 0 ;
	setAttr ".uvtk[6]" -type "float2" -0.32159624 0 ;
	setAttr ".uvtk[7]" -type "float2" -0.32159624 0 ;
	setAttr ".uvtk[8]" -type "float2" -0.32159624 0 ;
	setAttr ".uvtk[9]" -type "float2" -0.32159624 0 ;
	setAttr ".uvtk[10]" -type "float2" -0.32159624 0 ;
	setAttr ".uvtk[11]" -type "float2" -0.32159624 0 ;
	setAttr ".uvtk[154]" -type "float2" -0.32159624 0 ;
createNode polyMapCut -n "polyMapCut2";
	rename -uid "1AB3EE5D-4855-EEBB-C751-C8BEAC1711A2";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[96:107]";
createNode polyMapCut -n "polyMapCut3";
	rename -uid "8AE3ABFB-4B6E-4980-E960-59BBDDAF3AB2";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 11 "e[266]" "e[268]" "e[270]" "e[272]" "e[274]" "e[276]" "e[278]" "e[280]" "e[282]" "e[284]" "e[286:287]";
createNode polyMapCut -n "polyMapCut4";
	rename -uid "44B27F2C-42A5-7D48-5869-FDBA5B0056C2";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 17 "e[113]" "e[125]" "e[137]" "e[149]" "e[161]" "e[173]" "e[185]" "e[197]" "e[209]" "e[234]" "e[236]" "e[273]" "e[302]" "e[304]" "e[333]" "e[359]" "e[383]";
createNode polyTweakUV -n "polyTweakUV2";
	rename -uid "8092F1B1-453D-CDD8-2D25-8FB2F4D29444";
	setAttr ".uopa" yes;
	setAttr -s 192 ".uvtk";
	setAttr ".uvtk[12]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[13]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[14]" -type "float2" -0.016431883 0 ;
	setAttr ".uvtk[15]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[16]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[17]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[25]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[26]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[27]" -type "float2" -0.016431883 0 ;
	setAttr ".uvtk[28]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[29]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[38]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[39]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[40]" -type "float2" -0.016431883 0 ;
	setAttr ".uvtk[41]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[42]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[51]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[52]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[53]" -type "float2" -0.016431883 0 ;
	setAttr ".uvtk[54]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[55]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[64]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[65]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[66]" -type "float2" -0.016431883 0 ;
	setAttr ".uvtk[67]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[68]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[77]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[78]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[79]" -type "float2" -0.016431883 0 ;
	setAttr ".uvtk[80]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[81]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[90]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[91]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[92]" -type "float2" -0.016431883 0 ;
	setAttr ".uvtk[93]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[94]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[103]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[104]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[105]" -type "float2" -0.016431883 0 ;
	setAttr ".uvtk[106]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[107]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[116]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[117]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[118]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[119]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[120]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[121]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[122]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[123]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[124]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[125]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[126]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[127]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[129]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[130]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[131]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[132]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[133]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[134]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[135]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[136]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[137]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[138]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[139]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[140]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[141]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[142]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[143]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[144]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[145]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[146]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[147]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[148]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[149]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[150]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[151]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[152]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[153]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[155]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[156]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[157]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[158]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[159]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[160]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[161]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[162]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[163]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[164]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[165]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[166]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[167]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[168]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[169]" -type "float2" 0.38849762 0 ;
	setAttr ".uvtk[170]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[171]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[172]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[173]" -type "float2" 0.38849762 0 ;
	setAttr ".uvtk[174]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[175]" -type "float2" 0.38849762 0 ;
	setAttr ".uvtk[176]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[177]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[178]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[179]" -type "float2" 0.38849762 0 ;
	setAttr ".uvtk[180]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[181]" -type "float2" 0.38849762 0 ;
	setAttr ".uvtk[182]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[183]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[184]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[185]" -type "float2" 0.38849762 0 ;
	setAttr ".uvtk[186]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[187]" -type "float2" 0.38849762 0 ;
	setAttr ".uvtk[188]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[189]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[190]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[191]" -type "float2" 0.38849762 0 ;
	setAttr ".uvtk[192]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[193]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[194]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[195]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[196]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[197]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[198]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[199]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[200]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[201]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[202]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[203]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[204]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[205]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[206]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[207]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[208]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[209]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[210]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[211]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[212]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[213]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[214]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[215]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[216]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[217]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[218]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[219]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[220]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[221]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[222]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[223]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[224]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[225]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[226]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[227]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[228]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[229]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[230]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[231]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[233]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[234]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[241]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[242]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[243]" -type "float2" -0.016431883 0 ;
	setAttr ".uvtk[244]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[245]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[246]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[247]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[248]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[249]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[250]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[251]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[252]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[253]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[254]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[255]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[256]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[257]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[258]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[259]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[260]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[261]" -type "float2" 0 0.032863852 ;
	setAttr ".uvtk[262]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[263]" -type "float2" -0.27816901 0 ;
	setAttr ".uvtk[264]" -type "float2" 0.38849768 0 ;
	setAttr ".uvtk[265]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[266]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[267]" -type "float2" 0 0.03286387 ;
	setAttr ".uvtk[270]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[271]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[272]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[273]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[274]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[275]" -type "float2" -0.016431943 0 ;
	setAttr ".uvtk[276]" -type "float2" -0.016431943 0 ;
createNode polyMapSewMove -n "polyMapSewMove1";
	rename -uid "731304E6-49CD-6A09-2275-2CAF5C33CD40";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 5 "e[234]" "e[236]" "e[333]" "e[359]" "e[383]";
createNode polyMapSewMove -n "polyMapSewMove2";
	rename -uid "BA52CDD7-4083-CEA7-2C2B-3B8753E57CBE";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 8 "e[113]" "e[125]" "e[137]" "e[149]" "e[161]" "e[173]" "e[185]" "e[197]";
createNode polyTweakUV -n "polyTweakUV3";
	rename -uid "DF763CD4-4B40-62C8-501D-259AF83D4538";
	setAttr ".uopa" yes;
	setAttr -s 262 ".uvtk";
	setAttr ".uvtk[0:249]" -type "float2" 0.0034855506 0.064482555 0.0034855506
		 0.064482547 0.0034855357 0.064482547 0.0034855432 0.064482547 0.0034855432 0.064482555
		 0.0034855432 0.064482555 0.0034855432 0.064482555 0.0034855432 0.06448254 0.0034855357
		 0.06448254 0.0034855506 0.06448254 0.0034855506 0.064482555 0.0034855506 0.064482555
		 0.0087138303 -0.27994558 0.0087138899 -0.27994558 0.0087138303 -0.27994558 0.0087138303
		 -0.27994558 0.0087138303 -0.27994558 0.0087138899 -0.27994558 0.0087138005 -0.27994558
		 0.0087138005 -0.27994558 0.0087138005 -0.27994558 0.0087138005 -0.27994558 0.0087138005
		 -0.27994558 0.0087138005 -0.27994558 0.0087138005 -0.27994558 0.0087138303 -0.20342384
		 0.0087138899 -0.20342384 0.0087138303 -0.20342384 0.0087138303 -0.20342384 0.0087138303
		 -0.20342384 0.0087138899 -0.20342384 0.0087138005 -0.20342384 0.0087138005 -0.20342384
		 0.0087138005 -0.20342384 0.0087138005 -0.20342384 0.0087138005 -0.20342384 0.0087138005
		 -0.20342384 0.0087138005 -0.20342384 0.0087138303 -0.12690207 0.0087138899 -0.12690207
		 0.0087138303 -0.12690207 0.0087138303 -0.12690207 0.0087138303 -0.12690207 0.0087138899
		 -0.12690207 0.0087138005 -0.12690207 0.0087138005 -0.12690207 0.0087138005 -0.12690207
		 0.0087138005 -0.12690207 0.0087138005 -0.12690207 0.0087138005 -0.12690207 0.0087138005
		 -0.12690207 0.0087138303 -0.050380286 0.0087138899 -0.050380286 0.0087138303 -0.050380286
		 0.0087138303 -0.050380286 0.0087138303 -0.050380286 0.0087138899 -0.050380286 0.0087138005
		 -0.050380286 0.0087138005 -0.050380286 0.0087138005 -0.050380286 0.0087138005 -0.050380286
		 0.0087138005 -0.050380286 0.0087138005 -0.050380286 0.0087138005 -0.050380286 0.0087138303
		 0.02614144 0.0087138899 0.02614144 0.0087138303 0.02614144 0.0087138303 0.02614144
		 0.0087138303 0.02614144 0.0087138899 0.02614144 0.0087138005 0.02614144 0.0087138005
		 0.02614144 0.0087138005 0.02614144 0.0087138005 0.02614144 0.0087138005 0.02614144
		 0.0087138005 0.02614144 0.0087138005 0.02614144 0.0087138303 0.10266321 0.0087138899
		 0.10266321 0.0087138303 0.10266321 0.0087138303 0.10266321 0.0087138303 0.10266321
		 0.0087138899 0.10266321 0.0087138005 0.10266321 0.0087138005 0.10266321 0.0087138005
		 0.10266321 0.0087138005 0.10266321 0.0087138005 0.10266321 0.0087138005 0.10266321
		 0.0087138005 0.10266321 0.0087138303 0.17918514 0.0087138899 0.17918514 0.0087138303
		 0.17918514 0.0087138303 0.17918514 0.0087138303 0.17918514 0.0087138899 0.17918514
		 0.0087138005 0.17918514 0.0087138005 0.17918514 0.0087138005 0.17918514 0.0087138005
		 0.17918514 0.0087138005 0.17918514 0.0087138005 0.17918514 0.0087138005 0.17918514
		 0.0087138303 0.25570688 0.0087138899 0.25570688 0.0087138303 0.25570688 0.0087138303
		 0.25570688 0.0087138303 0.25570688 0.0087138899 0.25570688 0.0087138005 0.25570688
		 0.0087138005 0.25570688 0.0087138005 0.25570688 0.0087138005 0.25570688 0.0087138005
		 0.25570688 0.0087138005 0.25570688 0.0087138005 0.25570688 0.32589829 -0.26595336
		 0.32589829 -0.26595336 0.32589829 -0.26595336 0.32589829 -0.26595336 0.32589829 -0.26595336
		 0.32589829 -0.26595336 0.32589829 -0.26595336 0.32589829 -0.26595336 0.32589829 -0.26595336
		 0.32589829 -0.26595336 0.32589829 -0.26595336 0.32589829 -0.26595336 0.0087138005
		 0.33222869 0.32589829 -0.21156603 0.32589829 -0.21156603 0.32589829 -0.21156603 0.32589829
		 -0.21156603 0.32589829 -0.21156603 0.32589829 -0.21156603 0.32589829 -0.21156603
		 0.32589829 -0.21156603 0.32589829 -0.21156603 0.32589829 -0.21156603 0.32589829 -0.21156603
		 0.32589829 -0.21156603 0.32589829 -0.21156603 -0.012199393 -0.1272224 -0.011333219
		 -0.13272963 -0.013511605 -0.13994108 -0.019522831 -0.14711224 -0.029587489 -0.15149389
		 -0.040415563 -0.10545205 -0.031313755 -0.10115252 -0.021887962 -0.10202776 -0.014025484
		 -0.10677551 -0.0096700713 -0.11450737 -0.0096265301 -0.12233346 -0.012199393 -0.1272224
		 0.0034855357 0.064482555 -0.060997088 -0.074939199 0.32589829 -0.26595336 0.32589829
		 -0.26595336 0.32589829 -0.26595336 0.32589829 -0.26595336 0.32589829 -0.26595336
		 0.32589829 -0.26595336 0.32589829 -0.26595336 0.32589829 -0.26595336 0.32589829 -0.26595336
		 0.32589829 -0.26595336 0.32589829 -0.26595336 0.32589829 -0.26595336 0.32589829 -0.26595336
		 -0.060996998 -0.074939169 -0.060996998 -0.074939169 -0.060997088 -0.074939169 -0.060997088
		 -0.074939169 -0.060997028 -0.074939169 -0.060997088 -0.074939199 -0.060997028 -0.074939199
		 -0.060997088 -0.074939169 -0.060997088 -0.074939169 -0.060996998 -0.074939169 -0.060996998
		 -0.074939199 -0.060996998 -0.074939199 -0.060996998 -0.074939169 -0.060996998 -0.074939169
		 -0.060997088 -0.074939169 -0.060997088 -0.074939169 -0.060997028 -0.074939169 -0.060997088
		 -0.074939199 -0.060997028 -0.074939199 -0.060997088 -0.074939169 -0.060997088 -0.074939169
		 -0.060996998 -0.074939169 -0.060996998 -0.074939199 -0.060996998 -0.074939199 0.32589829
		 -0.22144046 0.32589829 -0.22144046 0.32589829 -0.22144046 0.32589829 -0.22144046
		 0.32589829 -0.22144046 0.32589829 -0.22144046 0.32589829 -0.22144046 0.32589829 -0.22144046
		 0.32589829 -0.22144046 0.32589829 -0.22144046 0.32589829 -0.22144046 0.32589829 -0.22144046
		 0.32589829 -0.22144046 0.32589829 -0.25487238 0.32589829 -0.25487238 0.32589829 -0.25487238
		 0.32589829 -0.25487238 0.32589829 -0.25487238 0.32589829 -0.25487238 0.32589829 -0.25487238
		 0.32589829 -0.25487238 0.32589829 -0.25487238 0.32589829 -0.25487238 0.32589829 -0.25487238
		 0.32589829 -0.25487238 0.32589829 -0.25487238 0.32589829 -0.23799512 0.32589829 -0.23799512
		 0.32589829 -0.23799512 0.32589829 -0.23799512 0.32589829 -0.23799512 0.32589829 -0.23799512
		 0.32589829 -0.23799512 0.32589829 -0.23799512 0.32589829 -0.23799512 0.32589829 -0.23799512
		 0.32589829 -0.23799512 0.32589829 -0.23799512 0.32589829 -0.23799512 0.0087138005
		 0.33222869 0.0087138303 0.33222869 0.32589829 -0.26595336 0.0087138005 0.33222869
		 0.0087138005 0.33222869 0.0087138005 0.33222869 0.0087138005 0.33222869 0.0087138005
		 0.33222869 0.0087138899 0.33222869 0.0087138303 0.33222869 0.0087138303 0.33222869
		 0.0087138303 0.33222869 0.0087138899 0.33222869 -0.089733489 -0.12542051 -0.079725392
		 -0.1585878 -0.080220886 -0.090921097 -0.054283001 -0.06736701 -0.020085953 -0.061466865;
	setAttr ".uvtk[250:261]" 0.012224372 -0.075026028 0.03316997 -0.10414539 0.036820807
		 -0.14023076 0.034294873 -0.14692627 0.012547324 -0.17426775 -0.019737519 -0.18665479
		 -0.05375538 -0.18094586 -0.041119769 -0.14999662 -0.060997088 -0.074939199 0.03940627
		 -0.11240452 -0.060997088 -0.074939199 0.0034855432 0.064482555;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 4 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 6 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "layer2.di" "tikitorch.do";
connectAttr "polyTweakUV3.out" "tikitorchShape.i";
connectAttr "polyTweakUV3.uvtk[0]" "tikitorchShape.uvst[0].uvtw";
connectAttr "layer1.di" "flame.do";
connectAttr "polySoftEdge5.out" "flameShape.i";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "rampShader1SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "rampShader2SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "rampShader1SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "rampShader2SG.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "polyTweak1.out" "polyExtrudeFace1.ip";
connectAttr "tikitorchShape.wm" "polyExtrudeFace1.mp";
connectAttr "polyCylinder1.out" "polyTweak1.ip";
connectAttr "polyTweak2.out" "polyExtrudeFace2.ip";
connectAttr "tikitorchShape.wm" "polyExtrudeFace2.mp";
connectAttr "polyExtrudeFace1.out" "polyTweak2.ip";
connectAttr "polyExtrudeFace2.out" "polyExtrudeFace3.ip";
connectAttr "tikitorchShape.wm" "polyExtrudeFace3.mp";
connectAttr "polyExtrudeFace3.out" "polySplitRing1.ip";
connectAttr "tikitorchShape.wm" "polySplitRing1.mp";
connectAttr "polySplitRing1.out" "polySplitRing2.ip";
connectAttr "tikitorchShape.wm" "polySplitRing2.mp";
connectAttr "polySplitRing2.out" "polySplitRing3.ip";
connectAttr "tikitorchShape.wm" "polySplitRing3.mp";
connectAttr "polyTweak3.out" "polySoftEdge1.ip";
connectAttr "tikitorchShape.wm" "polySoftEdge1.mp";
connectAttr "polySplitRing3.out" "polyTweak3.ip";
connectAttr "polySoftEdge1.out" "polySoftEdge2.ip";
connectAttr "tikitorchShape.wm" "polySoftEdge2.mp";
connectAttr "polySoftEdge2.out" "polySoftEdge3.ip";
connectAttr "tikitorchShape.wm" "polySoftEdge3.mp";
connectAttr "polySoftEdge3.out" "polySoftEdge4.ip";
connectAttr "tikitorchShape.wm" "polySoftEdge4.mp";
connectAttr "rampShader1.oc" "rampShader1SG.ss";
connectAttr "rampShader1SG.msg" "materialInfo1.sg";
connectAttr "rampShader1.msg" "materialInfo1.m";
connectAttr "rampShader1.msg" "materialInfo1.t" -na;
connectAttr "rampShader2.oc" "rampShader2SG.ss";
connectAttr "flameShape.iog" "rampShader2SG.dsm" -na;
connectAttr "rampShader2SG.msg" "materialInfo2.sg";
connectAttr "rampShader2.msg" "materialInfo2.m";
connectAttr "rampShader2.msg" "materialInfo2.t" -na;
connectAttr "layerManager.dli[1]" "layer1.id";
connectAttr "layerManager.dli[2]" "layer2.id";
connectAttr "polyTweak4.out" "polySoftEdge5.ip";
connectAttr "flameShape.wm" "polySoftEdge5.mp";
connectAttr "polySphere1.out" "polyTweak4.ip";
connectAttr "polySoftEdge4.out" "polyMapCut1.ip";
connectAttr "polyMapCut1.out" "polyTweakUV1.ip";
connectAttr "polyTweakUV1.out" "polyMapCut2.ip";
connectAttr "polyMapCut2.out" "polyMapCut3.ip";
connectAttr "polyMapCut3.out" "polyMapCut4.ip";
connectAttr "polyMapCut4.out" "polyTweakUV2.ip";
connectAttr "polyTweakUV2.out" "polyMapSewMove1.ip";
connectAttr "polyMapSewMove1.out" "polyMapSewMove2.ip";
connectAttr "polyMapSewMove2.out" "polyTweakUV3.ip";
connectAttr "rampShader1SG.pa" ":renderPartition.st" -na;
connectAttr "rampShader2SG.pa" ":renderPartition.st" -na;
connectAttr "rampShader1.msg" ":defaultShaderList1.s" -na;
connectAttr "rampShader2.msg" ":defaultShaderList1.s" -na;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "tikitorchShape.iog" ":initialShadingGroup.dsm" -na;
// End of tikitorch.ma
