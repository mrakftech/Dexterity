﻿namespace Dexterity.UiServices;

public interface ITrayService
{
    void Initialize();

    Action ClickHandler { get; set; }
}