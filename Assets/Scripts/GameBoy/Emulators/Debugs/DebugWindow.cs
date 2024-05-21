using GameBoy.Emulators.Common;
using MyUtils.R3;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameBoy.Emulators.Debugs
{
    public class DebugWindow : ObservableMonoBehaviour
    {
        [SerializeField]
        private bool _showDebugWindow;

        [SerializeField]
        private GameObject _debugWindow;
        [SerializeField]
        private Slider _gameSpeedSlider;
        [SerializeField]
        private TextMeshProUGUI _tmp__gameSpeedSlider;

        [SerializeField]
        private Emulator _emulator;

        protected override void OnEnableInit(ref DisposableBuilder builder)
        {
            Observable.EveryValueChanged(_gameSpeedSlider, x => x.value)
                      .Select(v => Mathf.Clamp01(v))
                      .Subscribe(v =>
                       {
                           Cpu.ClockSpeedScale = v;
                           _tmp__gameSpeedSlider.SetText($"speed:{v:P2}");
                       })
                      .AddTo(ref builder);

            Observable.EveryValueChanged(this, _ => _showDebugWindow)
                      .Where(_ => _debugWindow)
                      .Subscribe(v => _debugWindow.SetActive(v))
                      .AddTo(ref builder);
        }
    }
}