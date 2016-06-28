using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using UnityEditor.UI;

public class GachaTestWindow : EditorWindow
{
   

    private GameObject _selected = null;
    private GameObject _sceneInstance = null;

    

    [MenuItem("Window/Gacha Tester")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<GachaTestWindow>();
    }

    void OnGUI()
    {
        if (_selected != null)
        {
            if (_sceneInstance == null)
            {
                _sceneInstance = Instantiate<GameObject>(_selected);
            }

            _selected.name = GUILayout.TextField(_selected.name);
            Gacha script = _selected.GetComponent<Gacha>();
            Debug.Assert(script, "Could not find script");

            Animator animator = _selected.GetComponent<Animator>();
            animator.enabled = EditorGUILayout.ToggleLeft("Is Animated", animator.enabled);
            if (animator.enabled)
            {
               
                //avatar
                animator.avatar = (Avatar)EditorGUILayout.ObjectField("Avatar", animator.avatar, typeof (Avatar), false);
                //animation controller
                RuntimeAnimatorController controller = animator.runtimeAnimatorController;
                controller = (RuntimeAnimatorController)EditorGUILayout.ObjectField("Controller", controller, typeof(RuntimeAnimatorController), false);
                //special animation
                script.HasSpecialAnimation = EditorGUILayout.ToggleLeft("Has Special Animation",
                    script.HasSpecialAnimation);
                if (script.HasSpecialAnimation)
                {
                    EditorGUI.indentLevel++;
                    script.SpecialAnimation = (AnimationClip)EditorGUILayout.ObjectField("Special Animation", script.SpecialAnimation,
                        typeof (AnimationClip), false);
                    if (script.SpecialAnimation && GUILayout.Button("Special Animation"))
                    {
                        AnimationMode.SampleAnimationClip(_sceneInstance, script.SpecialAnimation, script.SpecialAnimation.length);
                    }

                }

                
                EditorGUI.indentLevel--;
            }

        }
        else
        {
            if (_sceneInstance)
            {
                DestroyImmediate(_sceneInstance);
            }
        }

        SceneView.RepaintAll();
    }

    void OnSelectionChange()
    {
        
        if (Selection.activeObject == null)
        {
            return;
        }
        PrefabType fabType = PrefabUtility.GetPrefabType(Selection.activeObject);
        if (fabType == PrefabType.Prefab && Selection.activeGameObject.layer == LayerMask.NameToLayer("Gacha"))
        {
            if (Selection.activeGameObject != _selected)
            {
                _selected = Selection.activeGameObject;
                if (_sceneInstance != null)
                {
                    DestroyImmediate(_sceneInstance);
                    _sceneInstance = null;
                }
            }
            
        }
        else
        {
            _selected = null;
        }
        this.Repaint();
    }
}
