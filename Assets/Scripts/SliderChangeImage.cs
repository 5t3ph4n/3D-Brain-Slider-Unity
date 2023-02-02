// Code Modified By Stephan Gorgey 
// Licensed under the MIT License.
using System.Collections;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("Image Changer")]
    public class SliderChangeImage : MonoBehaviour
    {
        [SerializeField]
        private Renderer TargetRenderer;

                //Indexing Variables
                public double XcurrentImage = 0;
                public double YcurrentImage = 0;
                public double ZcurrentImage = 0;
                //Sliders
                public PinchSlider Xslider;
                public PinchSlider Yslider;
                public PinchSlider Zslider;
                //Images array
                public Sprite[] Ximages;
                public Sprite[] Yimages;
                public Sprite[] Zimages;

        void Start()
        {
            // Load images from the "Resources" folder
            if(Resources.Load<Sprite>("XImages/1") != null)
            {
                Ximages = Resources.LoadAll<Sprite>("XImages"); 

                Yimages = Resources.LoadAll<Sprite>("YImages"); 

                Zimages = Resources.LoadAll<Sprite>("ZImages"); 
            }
            else
            {
                Debug.LogError("Could not find the specified folder");
            }
        }
        int RoundToWholeInteger(float number)
        {
            if (number >= 0.5f)
            {
                return (int)Mathf.Ceil(number);
            }
            else
            {
                return (int)Mathf.Floor(number);
            }
        }

        public void OnSliderUpdatedX(SliderEventData eventData)
        {
            double ratio = 1.0 / (1.0* Ximages.Length) ; 
            double val = (double) eventData.NewValue ;
            XcurrentImage = val/ ratio;
            int ind =  RoundToWholeInteger((float)XcurrentImage)-1;
                if (ind < 0)
                {
                    ind = 0;
                }
            GetComponent<Image>().sprite = Ximages[ind];
        }

        public void OnSliderUpdatedY(SliderEventData eventData)
        {
            double ratio = 1.0 / (1.0* Yimages.Length) ; 
            double val = (double) eventData.NewValue ;
            YcurrentImage = val/ ratio;
            int ind =  RoundToWholeInteger((float)YcurrentImage)-1;
                if (ind < 0)
                {
                    ind = 0;
                }
            GetComponent<Image>().sprite = Yimages[ind];
        }

        public void OnSliderUpdateZ(SliderEventData eventData)
        {
            double ratio = 1.0 / (1.0* Zimages.Length) ; 
            double val = (double) eventData.NewValue ;
            ZcurrentImage = val/ ratio;
            int ind =  RoundToWholeInteger((float)ZcurrentImage)-1;
                if (ind < 0)
                {
                    ind = 0;
                }
            GetComponent<Image>().sprite = Zimages[ind];
        }
    }
}
