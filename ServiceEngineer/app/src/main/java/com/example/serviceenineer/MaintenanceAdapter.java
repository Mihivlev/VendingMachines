package com.example.serviceenineer;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class MaintenanceAdapter extends RecyclerView.Adapter<MaintenanceAdapter.MaintenanceVH> {
    Context context;
    List<Maintenance> itemList;
    List<VendingMachines> VAList;

    public MaintenanceAdapter(Context context, List<Maintenance> itemList, List<VendingMachines> VAList) {
        this.context = context;
        this.itemList = itemList;
        this.VAList = VAList;
    }

    @NonNull
    @Override
    public MaintenanceVH onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(context).inflate(R.layout.maintenance, parent, false);
        return new MaintenanceVH(v);
    }

    public void setItemLists(List<Maintenance> itemList, List<VendingMachines> VAList){
        this.itemList = itemList;
        this.VAList = VAList;
    }

    @Override
    public void onBindViewHolder(@NonNull MaintenanceVH holder, int position) {
        holder.Date.setText(itemList.get(position).getDate());
        holder.VA.setText(FindVA(itemList.get(position).getVA()));
        holder.WorkDescription.setText(itemList.get(position).getWork_description());
    }

    public String FindVA(String id){
        for(int i = 0; i < VAList.size();i++)
            if (VAList.get(i).getId().equals(id))
                return  VAList.get(i).getSerial_number();
        return "Not found";
    }

    @Override
    public int getItemCount() {
        return itemList.size();
    }

    public static class MaintenanceVH extends RecyclerView.ViewHolder{
        TextView Date;
        TextView VA;
        TextView WorkDescription;
        public MaintenanceVH(@NonNull View view){
            super(view);
            Date = view.findViewById(R.id.MaintenanceDate);
            VA = view.findViewById(R.id.MaintenanceVA);
            WorkDescription = view.findViewById(R.id.MaintenanceWorkDescription);
        }
    }
}
