package md5391b6db810cdb4c0c4a00257201dc5f1;


public class MyBroadcastReceiver
	extends md5214eafb7e7b3b7fcc363a68a6358563f.GcmBroadcastReceiverBase_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("gladOS.Droid.Models.MyBroadcastReceiver, gladOS.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyBroadcastReceiver.class, __md_methods);
	}


	public MyBroadcastReceiver () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyBroadcastReceiver.class)
			mono.android.TypeManager.Activate ("gladOS.Droid.Models.MyBroadcastReceiver, gladOS.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
