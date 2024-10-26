using UnityEngine;

public class VictoryChoreographer : MonoBehaviour
{ 
    private int _presentEpoch;

    private void Awake()
    {
        VitalityMatrixCraft();
    }

    private void VitalityMatrixCraft()
    {
        _presentEpoch = PlayerPrefs.GetInt(AvatarPhaseSetup.PresentStage, 0);
    }

    public void TriumphChime()
    {
        PlayerPrefs.SetInt(AvatarPhaseSetup.PresentStage, _presentEpoch);
        PlayerPrefs.Save();
        
        var chronicleOverseer = FindObjectOfType<TrajectoryGuide>();
        chronicleOverseer.FulfillStageObjective(_presentEpoch);
    }
}