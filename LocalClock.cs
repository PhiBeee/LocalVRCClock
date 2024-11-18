
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
using System;

namespace PhiBee{
    public class LocalClock : UdonSharpBehaviour
    {
        public TextMeshProUGUI clock;
        private string localTime;

        public void Start(){
            localTime = getTime();
            
            clock.text = localTime;
        }

        public void Update(){
            string tmp = getTime();
            if(tmp.CompareTo(localTime) != 0){
                localTime = tmp;
                clock.text = localTime;
            }
        }

        private string getTime(){
            var now = DateTime.Now;
            var utcNow = now.ToUniversalTime();
            var localOffsetMin = (int)(now - utcNow).TotalMinutes;
            var localTimeTmp = (DateTime.UtcNow + TimeSpan.FromMinutes(localOffsetMin)).ToString("hh:mm tt");

            return localTimeTmp;
        }
    }
}
