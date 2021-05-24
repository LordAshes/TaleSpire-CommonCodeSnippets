# Position And Rotation Of Mini

It seems the best Position and Rotation information regarding a mini is obtained from:

````C#
asset.BaseLoader.gameObject.transform
````
because this gets the position and rotation of the mini's base. This means that even if the creature portion of the mini is offset,
the position and rotation information will be correct with respect to the mini's base.

The transform property exposed a number of sub-propeties including:

````C#
asset.BaseLoader.gameObject.transform.position
````
and
````C#
asset.BaseLoader.gameObject.transform.rotation
````
and
````C#
asset.BaseLoader.gameObject.transform.eulerAngles
````
