package vn.com.abc.docsoandroid;

import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

public class GhiChiSoActivity extends Fragment {

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {

        final View rootView = inflater.inflate(R.layout.activity_ghi_chi_so, container, false);

        try {
            Bundle bundle=getArguments();
            String strMonth = bundle.getString("ID");
            Toast.makeText(getActivity(), strMonth, Toast.LENGTH_SHORT).show();
        }
        catch (Exception ex){}

        return  rootView;
    }


}
