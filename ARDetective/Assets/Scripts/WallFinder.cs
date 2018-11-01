using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARDetective {

    public class WallFinder : MonoBehavior
    {
		public const float precision = 0.1;
        public List<Plane> allPlanes;// = populatePlanes();
		public List<Plane> wallPlanes;
		public List<Plane> obstaclePlanes;
		
		//Identifies the walls and obstacles currently identified by the game.
		//Gets inputs from allPlanes.
		//Returns to wallPlanes and obstaclePlanes.
		private void findFurthest() {
			wallPlanes.clear();
			obstaclePlanes.clear();
			
			foreach(Plane currplane in allPlanes) {
				bool matchedAngle = false;
				foreach(Plane farplane in wallPlanes) {
					if(Vector3.Angle(currplane.normal, farplane.normal) < precision){
						matchedAngle = true;
						if(currplane.distance > farplane.distance){
							obstaclePlanes.add(farplane);
							wallPlanes.remove(farplane);
							wallplanes.add(currplane);
						}
					}
				}
				if(!matchedAngle) {
					wallPlanes.add(currplane);
				}
			}
		}
		
		public void Start(){
			
		}
		
		public void Update(){
			
		}

        public static void main() { }
	}
	
}