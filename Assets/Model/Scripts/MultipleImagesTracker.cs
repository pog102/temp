using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MultipleImagesTracker : MonoBehaviour
{
    [SerializeField]
    List<GameObject> prefabsToSpawn = new List<GameObject>();

    private ARTrackedImageManager _trackedImageManager;
    private Dictionary<string, GameObject> _arObjects;

    private void Start()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
        if (_trackedImageManager == null)
        {
            Debug.LogError("ARTrackedImageManager not found!");
            return;
        }

        // ✅ Teisingas būdas prisijungti prie įvykio
        _trackedImageManager.trackedImagesChanged += OnImagesTrackedChanged;

        _arObjects = new Dictionary<string, GameObject>();
        SetupSceneElements();
    }

    private void OnDestroy()
    {
        if (_trackedImageManager != null)
        {
            // ✅ Teisingas būdas atsijungti
            _trackedImageManager.trackedImagesChanged -= OnImagesTrackedChanged;
        }
    }

    private void SetupSceneElements()
    {
        foreach (var prefab in prefabsToSpawn)
        {
            var arObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            arObject.name = prefab.name;
            arObject.gameObject.SetActive(false);
            _arObjects.Add(arObject.name, arObject);
        }
    }

    private void OnImagesTrackedChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
            UpdateTrackedImage(trackedImage);

        foreach (var trackedImage in eventArgs.updated)
            UpdateTrackedImage(trackedImage);

        foreach (var trackedImage in eventArgs.removed)
            DisableTrackedImage(trackedImage);
    }

    private void UpdateTrackedImage(ARTrackedImage trackedImage)
    {
        if (trackedImage == null)
            return;

        var imageName = trackedImage.referenceImage.name;
        if (!_arObjects.ContainsKey(imageName))
            return;

        var arObject = _arObjects[imageName];
        var animator = arObject.GetComponentInChildren<Animator>();

        // Kai žymė dalinai ar visiškai praranda sekimą (ranka uždengia)
        if (
            trackedImage.trackingState == TrackingState.Limited
            || trackedImage.trackingState == TrackingState.None
        )
        {
            if (animator != null)
                animator.SetBool("isWave", true); // keičia animaciją
            return;
        }

        // Žymė aiškiai matoma
        arObject.SetActive(true);
        arObject.transform.SetPositionAndRotation(
            trackedImage.transform.position,
            trackedImage.transform.rotation
        );

        if (animator != null)
            animator.SetBool("isWave", false); // grįžta į pradinę animaciją
    }

    private void DisableTrackedImage(ARTrackedImage trackedImage)
    {
        if (trackedImage == null)
            return;
        var imageName = trackedImage.referenceImage.name;
        if (_arObjects.ContainsKey(imageName))
        {
            _arObjects[imageName].SetActive(false);
        }
    }
}
