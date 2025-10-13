package com.example.serviceenineer;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Context;
import android.os.Bundle;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MaintenanceActivity extends AppCompatActivity {
    Context context;
    List<Maintenance> maintenanceList = new ArrayList<>();
    List<VendingMachines> VAList = new ArrayList<>();
    MaintenanceAdapter adapter;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_maintenance);

        context = this;

        RecyclerView view = findViewById(R.id.RVMaintenance);
        adapter = new MaintenanceAdapter(this,maintenanceList, VAList);
        view.setAdapter(adapter);

        LoadMaintenance();
    }

    public void LoadMaintenance(){
        Api.service.GetMaintenance(Api.user.getId()).enqueue(new Callback<List<Maintenance>>() {
            @Override
            public void onResponse(Call<List<Maintenance>> call, Response<List<Maintenance>> response) {
                maintenanceList = response.body();
                Api.service.GetVA().enqueue(new Callback<List<VendingMachines>>() {
                    @Override
                    public void onResponse(Call<List<VendingMachines>> call, Response<List<VendingMachines>> response) {
                        VAList = response.body();
                        adapter.setItemLists(maintenanceList, VAList);
                        adapter.notifyDataSetChanged();
                    }

                    @Override
                    public void onFailure(Call<List<VendingMachines>> call, Throwable t) {
                        Toast.makeText(context, t.toString(), Toast.LENGTH_LONG).show();
                    }
                });
            }

            @Override
            public void onFailure(Call<List<Maintenance>> call, Throwable t) {
                Toast.makeText(context, t.toString(), Toast.LENGTH_LONG).show();
            }
        });
    }
}