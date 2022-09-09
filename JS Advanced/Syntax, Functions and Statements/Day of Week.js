function day (dayNum){
    if(dayNum == 'Monday')
    { return 1; }
    else if(dayNum == 'Tuesday')
    {return 2; }
    else if(dayNum == 'Wednesday')
    {return 3; }
    else if(dayNum == 'Thursday')
    {return 4; }
    else if(dayNum == 'Friday')
    {return 5; }
    else if(dayNum == 'Saturday')
    {return 6; }
    else if(dayNum == 'Sunday')
    {return 7; }
    else{
        return 'error';
    }
}