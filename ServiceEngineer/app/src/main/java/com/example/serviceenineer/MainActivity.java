package com.example.serviceenineer;

import androidx.appcompat.app.AppCompatActivity;

import android.content.ActivityNotFoundException;
import android.content.Intent;
import android.os.Bundle;
import android.provider.MediaStore;
import android.view.View;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }
    public void MakePhoto(View view){
        Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        try {
        startActivityForResult(intent,1);
        }
        catch (ActivityNotFoundException e){
            Toast.makeText(this, e.toString(), Toast.LENGTH_LONG).show();
        }
    }
    public void MakeVideo(View view){
        Intent intent = new Intent(MediaStore.ACTION_VIDEO_CAPTURE);
        try {
            startActivityForResult(intent,1);
        }
        catch (ActivityNotFoundException e){
            Toast.makeText(this, e.toString(), Toast.LENGTH_LONG).show();
        }
    }
    public void ToNotes(View view){
        Intent notesActivity = new Intent(this, NotesActivity.class);
        startActivity(notesActivity);
    }
}