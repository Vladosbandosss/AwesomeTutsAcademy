using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactHealthUI : MonoBehaviour
{
    [SerializeField] private Slider _artifactSlider;

    [SerializeField] private Artifact _artifact;

    private void Start()
    {
        _artifactSlider.maxValue = _artifact.maxHealth;
        _artifactSlider.value = _artifact.maxHealth;
    }

    private void Update()
    {
        _artifactSlider.value = _artifact.health;
    }
}
