using Godot;
using Catcophony.scenes.time;

namespace Catcophony.scenes.gui.debug
{
    public partial class TimeDisplayControl : Control
    {
        private Label _timeDisplayLabel;

        public override void _Ready()
        {
            _timeDisplayLabel = GetNode<Label>("MarginContainer/TimeDisplayLabel");
            TimeSystem.Instance.TimeChange += OnTimeChange;
        }

        public override void _Process(double delta)
        {
        }

        public void OnTimeChange(string dateTimeStr)
        {
            _timeDisplayLabel.Text = dateTimeStr;
        }
    }
}
