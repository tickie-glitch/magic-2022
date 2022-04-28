This shader uses an exposed parametrised point parameter which you can change using "material.SetVector("_Param_Name", Vector3);"
 or you can uncheck the exposed checkbox to make it the same value accross all materials and use "Shader.SetGlobalVector("_Param_Name", Vector3);"
 from a C# script.

There are two shaders in the folder one would suck all vertices into the point, and the other would shrink the object
 while it is being sucked to the point.

See my tutorial on it: https://www.youtube.com/watch?v=eujfez6W53E

Don't forget to leave a review on the asset store, and contact me for any question or query at anasainea@gmail.com