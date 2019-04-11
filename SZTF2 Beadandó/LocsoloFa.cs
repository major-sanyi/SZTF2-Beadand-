﻿using System.Collections;
using System.Collections.Generic;

namespace SZTF2_Beadandó
{
    class LocsoloFa :IEnumerable<VizesBlokk>
    {
        public Locsolo gyökér;

        public LocsoloFa(Locsolo gyökér) {
            this.gyökér = gyökér;
        }
        //Azt tudom ez a foreach a masik meg a linq-s része a dolognak.
        //de hogy mi miért működik azt nem biztos
        public IEnumerator GetEnumerator()
        {
            foreach (var item in enumarate(gyökér))
            {
                yield return item;
            }
        }

        IEnumerator<VizesBlokk> IEnumerable<VizesBlokk>.GetEnumerator()
        {
            // return GetEnumerator();
            //yield return gyökér;
            foreach (var item in enumarate(gyökér))
            {
                yield return item;
            }

        }
        IEnumerable<VizesBlokk> enumarate( VizesBlokk jelenlegi)
        {
            

            if (jelenlegi==null||jelenlegi.GetType()==typeof(Palánta))
            {
                yield break;
            }
            yield return jelenlegi;
            foreach (var item in (jelenlegi as Locsolo).Kivezetes)
            {
                if (typeof(Palánta)==item.GetType())
                {
                    yield return item;
                }
                else
                foreach (var temp in (enumarate(item)))
                {
                    yield return temp;
                }
            }
        }
        
    }
  
}

