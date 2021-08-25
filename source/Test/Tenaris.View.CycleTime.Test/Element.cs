using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;

namespace Tenaris.View.CycleTime.Test {
   public class Element {
      public Element() {         
      }

      public string Name { get; set; }
      public bool IsExceededTime { get; set; }
      public string RealTime { get; set; }
      public string StandardTime { get; set; }
      public List<Preset> Presets { get; set; }
      public string Plc { get; set; }
   }
}




