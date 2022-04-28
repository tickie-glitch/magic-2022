This shader uses the scene color node so make sure that the opaque texture is enabled in quality settings,
 which is what the camera renders, this makes it greate for things like water in general but it will show 
 objects rendered before it, to make an object not show in the refraction at all, you can set its material to
 transparent (which changes its rendering order), or have a second camera the only renders the objects to be refracted to a render texture
 and use that in the shader.

There are two types of this shader, one is tangent which is better for sharp objects since it doesn't give good results on the UV seems of the mesh
 the other is view which is better for round and smooth objects but might produce weird result at some values of IOR
 
Note that this is an unlit shader so it will not recieve shadows and its reflections are based on reflection probes.


See my tutorial on it: https://www.youtube.com/watch?v=EELbMlnOzQE

Don't forget to leave a review on the asset store, and contact me for any question or query at anasainea@gmail.com