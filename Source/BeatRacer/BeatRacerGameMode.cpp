// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

#include "BeatRacerGameMode.h"
#include "BeatRacerPawn.h"
#include "BeatRacerHud.h"

ABeatRacerGameMode::ABeatRacerGameMode()
{
	DefaultPawnClass = ABeatRacerPawn::StaticClass();
	HUDClass = ABeatRacerHud::StaticClass();
}
