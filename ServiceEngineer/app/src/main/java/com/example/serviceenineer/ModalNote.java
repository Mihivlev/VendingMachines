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

public class ModalNote extends AppCompatActivity {
    Context context;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_modal_note);

        context = this;
    }

    public void SaveNote(View view){
        TextView title = findViewById(R.id.INoteTitle);
        TextView text = findViewById(R.id.INoteText);
        Notes note = new Notes(title.getText().toString(), text.getText().toString(), Api.user.getId());
        Api.service.PostNote(note).enqueue(new Callback<Notes>() {
            @Override
            public void onResponse(Call<Notes> call, Response<Notes> response) {
                finish();
            }

            @Override
            public void onFailure(Call<Notes> call, Throwable t) {
                Toast.makeText(context, toString(), Toast.LENGTH_LONG).show();
            }
        });
    }
}