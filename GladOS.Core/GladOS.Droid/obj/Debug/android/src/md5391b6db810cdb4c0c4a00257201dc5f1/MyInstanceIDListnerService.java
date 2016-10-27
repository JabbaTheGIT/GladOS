package md5391b6db810cdb4c0c4a00257201dc5f1;


public class MyInstanceIDListnerService
	extends com.google.android.gms.iid.InstanceIDListenerService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTokenRefresh:()V:GetOnTokenRefreshHandler\n" +
			"";
		mono.android.Runtime.register ("gladOS.Droid.Models.MyInstanceIDListnerService, gladOS.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyInstanceIDListnerService.class, __md_methods);
	}


	public MyInstanceIDListnerService () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyInstanceIDListnerService.class)
			mono.android.TypeManager.Activate ("gladOS.Droid.Models.MyInstanceIDListnerService, gladOS.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onTokenRefresh ()
	{
		n_onTokenRefresh ();
	}

	private native void n_onTokenRefresh ();

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
