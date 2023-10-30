using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BodyManager;

public class NPCBodyManager : MonoBehaviour
{
    [SerializeField] private Character salesCharacter;

    [SerializeField] private string[] bodyPartTypes;
    [SerializeField] private string state;
    [SerializeField] private string direction;

    private Animator animator;
    private AnimationClip animationClip;
    private AnimatorOverrideController animatorOverrideController;
    private AnimationClipOverrides defaultAnimationClips;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        defaultAnimationClips = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(defaultAnimationClips);

        UpdateBodyParts();
    }
    public void UpdateBodyParts()
    {
        for (int partIndex = 0; partIndex < bodyPartTypes.Length; partIndex++)
        {
            string partType = bodyPartTypes[partIndex];
            string partID = salesCharacter.characterParts[partIndex].bodyPart.animationID.ToString();

            animationClip = Resources.Load<AnimationClip>($"Character/{partType}/{partType}_{partID}_{state}_{direction}");
            defaultAnimationClips[$"{partType}_{0}_{state}_{direction}"] = animationClip;
        }
        animatorOverrideController.ApplyOverrides(defaultAnimationClips);
    }

}
