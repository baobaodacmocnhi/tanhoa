package vn.com.abc.docsoandroid;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TabHost;

public class Test extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_test);

        TabHost tabHost = (TabHost) findViewById(android.R.id.tabhost);
        TabHost.TabSpec tab1 = tabHost.newTabSpec("First Tab");
        TabHost.TabSpec tab2 = tabHost.newTabSpec("Second Tab");
        TabHost.TabSpec tab3 = tabHost.newTabSpec("Third tab");

        tab1.setIndicator("Tab1");
//        tab1.setContent(new Intent(this,DanhSachDocSoActivity.class));

        tab2.setIndicator("Tab2");
//        tab2.setContent(new Intent(this,DocSoActivity.class));

        tabHost.addTab(tab1);
        tabHost.addTab(tab2);
    }
}
