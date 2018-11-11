// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.
#pragma once
#include "GameFramework/HUD.h"
#include "BeatRacerHud.generated.h"


UCLASS(config = Game)
class ABeatRacerHud : public AHUD
{
	GENERATED_BODY()

public:
	ABeatRacerHud();

	/** Font used to render the vehicle info */
	UPROPERTY()
	UFont* HUDFont;

	// Begin AHUD interface
	virtual void DrawHUD() override;
	// End AHUD interface
};
