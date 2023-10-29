using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
    [SerializeField] private Character character;

    [SerializeField] private string[] bodyPartTypes;
    [SerializeField] private string[] characterStates;
    [SerializeField] private string[] characterDirections;

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
            string partID = character.characterParts[partIndex].bodyPart.animationID.ToString();

            for (int stateIndex = 0; stateIndex < characterStates.Length; stateIndex++)
            {
                string state = characterStates[stateIndex];
                for (int directionIndex = 0; directionIndex < characterDirections.Length; directionIndex++)
                {
                    string direction = characterDirections[directionIndex];

                    animationClip = Resources.Load<AnimationClip>($"Character/{partType}/{partType}_{partID}_{state}_{direction}");
                    defaultAnimationClips[$"{partType}_{0}_{state}_{direction}"] = animationClip;
                }
            }
        }
        animatorOverrideController.ApplyOverrides(defaultAnimationClips);
    }

    public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
    {
        public AnimationClipOverrides(int capacity) : base(capacity) { }

        public AnimationClip this[string name]
        {
            get { return this.Find(x => x.Key.name.Equals(name)).Value; }
            set
            {
                int index = this.FindIndex(x => x.Key.name.Equals(name));
                if (index != -1)
                    this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
            }
        }
    }
}

