package com.example.serviceenineer;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class DeletingActivity extends AppCompatActivity {

    int id;
    Context context;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_deleting);

        Bundle bundle = getIntent().getExtras();
        id = bundle.getInt("id");
        String name = bundle.getString("name");
        context = this;

        TextView textView = findViewById(R.id.TitleDeleting);
        textView.setText("Вы действительно хотите удалить заметку: " + name);
    }
    public void Delete(View view){
        Api.service.DeleteNote(id).enqueue(new Callback<Notes>() {
            @Override
            public void onResponse(Call<Notes> call, Response<Notes> response) {
                finish();
            }

            @Override
            public void onFailure(Call<Notes> call, Throwable t) {
                Toast.makeText(context, t.toString(), Toast.LENGTH_LONG).show();
            }
        });
    }
    public void Finish(View view){
        finish();
    }
}