using System.Collections.Generic;
using RefactoringExercise.SplitPhase.src;

namespace RefactoringExercise.SplitPhase {
    
    public class CourseStepsGetController {
        
        private Platform platform;

        public CourseStepsGetController(Platform platform) {
            this.platform = platform;
        }

        public List<results> get(string courseId) {

            List<results> result = new List <results>();
            Dictionary<string,double> csvSteps = platform.findCourseSteps(courseId);
            
            foreach(KeyValuePair<string, double> item in csvSteps) {
                
                string type = item.Key;
                double  duration = 0;
                double points = 0;
                
                if(type == "video") {
                    duration = item.Value * 1.1;
                }

                if(type == "quiz") {
                    duration = item.Value * 0.5;
                }

                if(type != "video" && type != "quiz") {
                    continue;
                }

                if(type == "video") {
                    points = item.Value * 1.1 * 100;
                }

                if(type == "quiz") {
                    points = item.Value * 0.5 * 10;
                }

                var results = new results {
                    type = item.Key,
                    duration = item.Value,
                    points = item.Value
                };
                
                result.Add(results);

            }
            
            return result;
        }
        
        public class results {
            public string type;
            public double duration;
            public double points;
        }

    }
    
}
