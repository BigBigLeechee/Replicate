using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour {

    private static int VOLUME_DATA_LENGTH = 128;    //录制的声音长

    private static MicrophoneInput mInstance;

    public float volume;        //音量

    private AudioClip mMicrophoneRecode;  //录制的音频
    private string mDeviceName;           //设备名称

    private const int frequency = 44100; //码率
    private const int lengthSec = 999;   //录制时长

    public static MicrophoneInput Instance{
        get{
            return mInstance;
        }
    }

    private void Awake() {
        mInstance = this;
    }

	// Use this for initialization
	void Start () {
        //获取设备名称
        mDeviceName = Microphone.devices[0];

        //录制一段音频
        mMicrophoneRecode = Microphone.Start(mDeviceName, true, lengthSec, frequency);
	}
	
	// Update is called once per frame
	void Update () {
        if(!GameController.Instance.IsGameOver()){
            volume = GetMaxVolume();
        }else{
            volume = 0f;
        }
        
	}


    /// <summary>
    /// 获取最大的音量
    /// </summary>
    /// 
    /// <returns>
    /// 音量大小
    /// </returns>
    private float GetMaxVolume()
    {
        float maxVolume = 0f;

        //用于储存一段时间内的音频信息
        float[] volumeData = new float[VOLUME_DATA_LENGTH];

        int offset;
        //获取录制的音频的开头位置
        offset = Microphone.GetPosition(mDeviceName) - VOLUME_DATA_LENGTH + 1;

        if(offset < 0)
        {
            return 0f;
        }

        //获取数据
        mMicrophoneRecode.GetData(volumeData, offset);

        for(int i = 0;i < VOLUME_DATA_LENGTH; i++)
        {
            float tempVolume = volumeData[i];
            if(tempVolume > maxVolume)
            {
                maxVolume = tempVolume;
            }
        }

        return maxVolume * maxVolume;
    }

    public float getVolume(){
        return volume;
    }
}
