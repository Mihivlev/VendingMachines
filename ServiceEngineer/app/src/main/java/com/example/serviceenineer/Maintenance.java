package com.example.serviceenineer;

import java.time.DateTimeException;
import java.util.Date;

public class Maintenance {
    private String date;
    private String vending_machine_id;
    private String work_description;

    public String getDate() {
        return date.substring(8,10)+"."+date.substring(5,7)+"."+date.substring(0,4);
    }

    public String getWork_description() {
        return work_description;
    }

    public String getVA() {
        return vending_machine_id;
    }
}
