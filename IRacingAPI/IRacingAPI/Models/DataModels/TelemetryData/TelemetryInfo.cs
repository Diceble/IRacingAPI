﻿namespace IRacingAPI.Models.DataModels.TelemetryData;
public class TelemetryInfo()
{
    //public TelemetryValue<string> Name { get; set; }
    public TelemetryValue<double> SessionTime { get; set; }
    public TelemetryValue<int> SessionTick { get; set; }
    public TelemetryValue<int> SessionNum { get; set; }
    public TelemetryValue<int> SessionState { get; set; }
    public TelemetryValue<int> SessionUniqueID { get; set; }
    public TelemetryValue<int> SessionFlags { get; set; }
    public TelemetryValue<double> SessionTimeRemain { get; set; }
    public TelemetryValue<int> SessionLapsRemain { get; set; }
    public TelemetryValue<int> SessionLapsRemainEx { get; set; }
    public TelemetryValue<double> SessionTimeTotal { get; set; }
    public TelemetryValue<int> SessionLapsTotal { get; set; }
    public TelemetryValue<int> SessionJokerLapsRemain { get; set; }
    public TelemetryValue<bool> SessionOnJokerLap { get; set; }
    public TelemetryValue<float> SessionTimeOfDay { get; set; }
    public TelemetryValue<int> RadioTransmitCarIdx { get; set; }
    public TelemetryValue<int> RadioTransmitRadioIdx { get; set; }
    public TelemetryValue<int> RadioTransmitFrequencyIdx { get; set; }
    public TelemetryValue<int> DisplayUnits { get; set; }
    public TelemetryValue<bool> DriverMarker { get; set; }
    public TelemetryValue<bool> PushToTalk { get; set; }
    public TelemetryValue<bool> PushToPass { get; set; }
    public TelemetryValue<bool> ManualBoost { get; set; }
    public TelemetryValue<bool> ManualNoBoost { get; set; }
    public TelemetryValue<bool> IsOnTrack { get; set; }
    public TelemetryValue<bool> IsReplayPlaying { get; set; }
    public TelemetryValue<int> ReplayFrameNum { get; set; }
    public TelemetryValue<int> ReplayFrameNumEnd { get; set; }
    public TelemetryValue<bool> IsDiskLoggingEnabled { get; set; }
    public TelemetryValue<bool> IsDiskLoggingActive { get; set; }
    public TelemetryValue<float> FrameRate { get; set; }
    public TelemetryValue<float> CpuUsageFG { get; set; }
    public TelemetryValue<float> GpuUsage { get; set; }
    public TelemetryValue<float> ChanAvgLatency { get; set; }
    public TelemetryValue<float> ChanLatency { get; set; }
    public TelemetryValue<float> ChanQuality { get; set; }
    public TelemetryValue<float> ChanPartnerQuality { get; set; }
    public TelemetryValue<float> CpuUsageBG { get; set; }
    public TelemetryValue<float> ChanClockSkew { get; set; }
    public TelemetryValue<float> MemPageFaultSec { get; set; }
    public TelemetryValue<float> MemSoftPageFaultSec { get; set; }
    public TelemetryValue<int> PlayerCarPosition { get; set; }
    public TelemetryValue<int> PlayerCarClassPosition { get; set; }
    public TelemetryValue<int> PlayerCarClass { get; set; }
    public TelemetryValue<int> PlayerTrackSurface { get; set; }
    public TelemetryValue<int> PlayerTrackSurfaceMaterial { get; set; }
    public TelemetryValue<int> PlayerCarIdx { get; set; }
    public TelemetryValue<int> PlayerCarTeamIncidentCount { get; set; }
    public TelemetryValue<int> PlayerCarMyIncidentCount { get; set; }
    public TelemetryValue<int> PlayerCarDriverIncidentCount { get; set; }
    public TelemetryValue<float> PlayerCarWeightPenalty { get; set; }
    public TelemetryValue<float> PlayerCarPowerAdjust { get; set; }
    public TelemetryValue<int> PlayerCarDryTireSetLimit { get; set; }
    public TelemetryValue<float> PlayerCarTowTime { get; set; }
    public TelemetryValue<bool> PlayerCarInPitStall { get; set; }
    public TelemetryValue<int> PlayerCarPitSvStatus { get; set; }
    public TelemetryValue<int> PlayerTireCompound { get; set; }
    public TelemetryValue<int> PlayerFastRepairsUsed { get; set; }
    public TelemetryValue<int> PaceMode { get; set; }
    public TelemetryValue<bool> OnPitRoad { get; set; }
    public TelemetryValue<float> SteeringWheelAngle { get; set; }
    public TelemetryValue<float> Throttle { get; set; }
    public TelemetryValue<float> Brake { get; set; }
    public TelemetryValue<float> Clutch { get; set; }
    public TelemetryValue<int> Gear { get; set; }
    public TelemetryValue<float> RPM { get; set; }
    public TelemetryValue<float> PlayerCarSLFirstRPM { get; set; }
    public TelemetryValue<float> PlayerCarSLShiftRPM { get; set; }
    public TelemetryValue<float> PlayerCarSLLastRPM { get; set; }
    public TelemetryValue<float> PlayerCarSLBlinkRPM { get; set; }
    public TelemetryValue<int> Lap { get; set; }
    public TelemetryValue<int> LapCompleted { get; set; }
    public TelemetryValue<float> LapDist { get; set; }
    public TelemetryValue<float> LapDistPct { get; set; }
    public TelemetryValue<int> RaceLaps { get; set; }
    public TelemetryValue<int> LapBestLap { get; set; }
    public TelemetryValue<float> LapBestLapTime { get; set; }
    public TelemetryValue<float> LapLastLapTime { get; set; }
    public TelemetryValue<float> LapCurrentLapTime { get; set; }
    public TelemetryValue<int> LapLasNLapSeq { get; set; }
    public TelemetryValue<float> LapLastNLapTime { get; set; }
    public TelemetryValue<int> LapBestNLapLap { get; set; }


    //-------------------------------------------------------------------------------------------------
    public TelemetryValue<float> LapBestNLapTime { get; set; }
    public TelemetryValue<float> LapDeltaToBestLap { get; set; }
    public TelemetryValue<float> LapDeltaToBestLap_DD { get; set; }
    public TelemetryValue<bool> LapDeltaToBestLap_OK { get; set; }
    public TelemetryValue<float> LapDeltaToOptimalLap { get; set; }
    public TelemetryValue<float> LapDeltaToOptimalLap_DD { get; set; }
    public TelemetryValue<bool> LapDeltaToOptimalLap_OK { get; set; }
    public TelemetryValue<float> LapDeltaToSessionBestLap { get; set; }
    public TelemetryValue<float> LapDeltaToSessionBestLap_DD { get; set; }
    public TelemetryValue<bool> LapDeltaToSessionBestLap_OK { get; set; }
    public TelemetryValue<float> LapDeltaToSessionOptimalLap { get; set; }
    public TelemetryValue<float> LapDeltaToSessionOptimalLap_DD { get; set; }
    public TelemetryValue<bool> LapDeltaToSessionOptimalLap_OK { get; set; }
    public TelemetryValue<float> LapDeltaToSessionLastlLap { get; set; }
    public TelemetryValue<float> LapDeltaToSessionLastlLap_DD { get; set; }
    public TelemetryValue<bool> LapDeltaToSessionLastlLap_OK { get; set; }
    public TelemetryValue<float> Speed { get; set; }
    public TelemetryValue<float> Yaw { get; set; }
    public TelemetryValue<float> YawNorth { get; set; }
    public TelemetryValue<float> Pitch { get; set; }
    public TelemetryValue<float> Roll { get; set; }
    public TelemetryValue<int> EnterExitReset { get; set; }
    public TelemetryValue<float> TrackTemp { get; set; }
    public TelemetryValue<float> TrackTempCrew { get; set; }
    public TelemetryValue<float> AirTemp { get; set; }
    public TelemetryValue<int> TrackWetness { get; set; }
    public TelemetryValue<int> Skies { get; set; }
    public TelemetryValue<float> AirDensity { get; set; }
    public TelemetryValue<float> AirPressure { get; set; }
    public TelemetryValue<float> WindVel { get; set; }
    public TelemetryValue<float> WindDir { get; set; }
    public TelemetryValue<float> RelativeHumidity { get; set; }
    public TelemetryValue<float> FogLevel { get; set; }
    public TelemetryValue<float> Precipitation { get; set; }
    public TelemetryValue<float> SolarAltitude { get; set; }
    public TelemetryValue<float> SolarAzimuth { get; set; }
    public TelemetryValue<bool> WeatherDeclaredWet { get; set; }
    public TelemetryValue<int> DCLapStatus { get; set; }
    public TelemetryValue<int> DCDriversSoFar { get; set; }
    public TelemetryValue<bool> OkToReloadTextures { get; set; }
    public TelemetryValue<bool> LoadNumTextures { get; set; }
    public TelemetryValue<int> CarLeftRight { get; set; }
    public TelemetryValue<bool> PitsOpen { get; set; }
    public TelemetryValue<bool> VidCapEnabled { get; set; }
    public TelemetryValue<bool> VidCapActive { get; set; }
    public TelemetryValue<float> PitRepairLeft { get; set; }
    public TelemetryValue<float> PitOptRepairLeft { get; set; }
    public TelemetryValue<bool> PitstopActive { get; set; }
    public TelemetryValue<int> FastRepairUsed { get; set; }
    public TelemetryValue<int> FastRepairAvailable { get; set; }
    public TelemetryValue<int> LFTiresUsed { get; set; }
    public TelemetryValue<int> RFTiresUsed { get; set; }
    public TelemetryValue<int> LRTiresUsed { get; set; }
    public TelemetryValue<int> RRTiresUsed { get; set; }
    public TelemetryValue<int> LeftTireSetsUsed { get; set; }
    public TelemetryValue<int> RightTireSetsUsed { get; set; }
    public TelemetryValue<int> FrontTireSetsUsed { get; set; }
    public TelemetryValue<int> RearTireSetsUsed { get; set; }
    public TelemetryValue<int> TireSetsUsed { get; set; }
    public TelemetryValue<int> LFTiresAvailable { get; set; }
    public TelemetryValue<int> RFTiresAvailable { get; set; }
    public TelemetryValue<int> LRTiresAvailable { get; set; }
    public TelemetryValue<int> RRTiresAvailable { get; set; }
    public TelemetryValue<int> LeftTireSetsAvailable { get; set; }
    public TelemetryValue<int> RightTireSetsAvailable { get; set; }
    public TelemetryValue<int> FrontTireSetsAvailable { get; set; }
    public TelemetryValue<int> RearTireSetsAvailable { get; set; }
    public TelemetryValue<int> TireSetsAvailable { get; set; }
    public TelemetryValue<int> CamCarIdx { get; set; }
    public TelemetryValue<int> CamCameraNumber { get; set; }
    public TelemetryValue<int> CamGroupNumber { get; set; }
    public TelemetryValue<int> CamCameraState { get; set; }
    public TelemetryValue<bool> IsOnTrackCar { get; set; }
    public TelemetryValue<bool> IsInGarage { get; set; }
    public TelemetryValue<float> SteeringWheelAngleMax { get; set; }
    public TelemetryValue<float> ShiftPowerPct { get; set; }
    public TelemetryValue<float> ShiftGrindRPM { get; set; }
    public TelemetryValue<float> ThrottleRaw { get; set; }
    public TelemetryValue<float> BrakeRaw { get; set; }
    public TelemetryValue<float> ClutchRaw { get; set; }
    public TelemetryValue<float> HandbrakeRaw { get; set; }
    public TelemetryValue<bool> BrakeABSactive { get; set; }
    public TelemetryValue<int> EngineWarnings { get; set; }
    public TelemetryValue<float> FuelLevelPct { get; set; }
    public TelemetryValue<int> PitSvFlags { get; set; }
    public TelemetryValue<float> PitSvLFP { get; set; }
    public TelemetryValue<float> PitSvRFP { get; set; }
    public TelemetryValue<float> PitSvLRP { get; set; }
    public TelemetryValue<float> PitSvRRP { get; set; }
    public TelemetryValue<float> PitSvFuel { get; set; }
    public TelemetryValue<int> PitSvTireCompound { get; set; }
    public TelemetryValue<float> SteeringWheelPctTorque { get; set; }
    public TelemetryValue<float> SteeringWheelPctTorqueSign { get; set; }
    public TelemetryValue<float> SteeringWheelPctTorqueSignStops { get; set; }
    public TelemetryValue<float> SteeringWheelPctIntensity { get; set; }
    public TelemetryValue<float> SteeringWheelPctSmoothing { get; set; }
    public TelemetryValue<float> SteeringWheelPctDamper { get; set; }
    public TelemetryValue<float> SteeringWheelLimiter { get; set; }
    public TelemetryValue<float> SteeringWheelMaxForceNm { get; set; }
    public TelemetryValue<float> SteeringWheelPeakForceNm { get; set; }
    public TelemetryValue<bool> SteeringWheelUseLinear { get; set; }
    public TelemetryValue<float> ShiftIndicatorPct { get; set; }
    public TelemetryValue<int> ReplayPlaySpeed { get; set; }
    public TelemetryValue<bool> ReplayPlaySlowMotion { get; set; }
    public TelemetryValue<double> ReplaySessionTime { get; set; }
    public TelemetryValue<int> ReplaySessionNum { get; set; }
    public TelemetryValue<float> TireLF_RumblePitch { get; set; }
    public TelemetryValue<float> TireRF_RumblePitch { get; set; }
    public TelemetryValue<float> TireLR_RumblePitch { get; set; }
    public TelemetryValue<float> TireRR_RumblePitch { get; set; }
    public TelemetryValue<bool> IsGarageVisible { get; set; }
    public TelemetryValue<float> SteeringWheelTorque { get; set; }
    public TelemetryValue<float> VelocityZ { get; set; }
    public TelemetryValue<float> VelocityY { get; set; }
    public TelemetryValue<float> VelocityX { get; set; }
    public TelemetryValue<float> YawRate { get; set; }
    public TelemetryValue<float> PitchRate { get; set; }
    public TelemetryValue<float> RollRate { get; set; }
    public TelemetryValue<float> VertAccel { get; set; }
    public TelemetryValue<float> LatAccel { get; set; }
    public TelemetryValue<float> LongAccel { get; set; }
    public TelemetryValue<bool> dcStarter { get; set; }
    public TelemetryValue<bool> dcPitSpeedLimiterToggle { get; set; }
    public TelemetryValue<bool> dcTractionControlToggle { get; set; }
    public TelemetryValue<bool> dcHeadlightFlash { get; set; }
    public TelemetryValue<float> dpRFTireChange { get; set; }
    public TelemetryValue<float> dpLFTireChange { get; set; }
    public TelemetryValue<float> dpRRTireChange { get; set; }
    public TelemetryValue<float> dpLRTireChange { get; set; }
    public TelemetryValue<float> dpFuelFill { get; set; }
    public TelemetryValue<float> dpFuelAutoFillEnabled { get; set; }
    public TelemetryValue<float> dpFuelAutoFillActive { get; set; }
    public TelemetryValue<float> dpWindshieldTearoff { get; set; }
    public TelemetryValue<float> dpFuelAddKg { get; set; }
    public TelemetryValue<float> dpFastRepair { get; set; }
    public TelemetryValue<float> dcBrakeBias { get; set; }
    public TelemetryValue<float> dpLFTireColdPress { get; set; }
    public TelemetryValue<float> dpRFTireColdPress { get; set; }
    public TelemetryValue<float> dpLRTireColdPress { get; set; }
    public TelemetryValue<float> dpRRTireColdPress { get; set; }
    public TelemetryValue<float> dcTractionControl { get; set; }
    public TelemetryValue<float> dcABS { get; set; }
    public TelemetryValue<bool> dcToggleWindshieldWipers { get; set; }
    public TelemetryValue<bool> dcTriggerWindshieldWipers { get; set; }
    public TelemetryValue<float> FuelUsePerHour { get; set; }
    public TelemetryValue<float> Voltage { get; set; }
    public TelemetryValue<float> WaterTemp { get; set; }
    public TelemetryValue<float> WaterLevel { get; set; }
    public TelemetryValue<float> FuelPress { get; set; }
    public TelemetryValue<float> OilTemp { get; set; }
    public TelemetryValue<float> OilPress { get; set; }
    public TelemetryValue<float> OilLevel { get; set; }
    public TelemetryValue<float> ManifoldPress { get; set; }
    public TelemetryValue<float> FuelLevel { get; set; }
    public TelemetryValue<float> Engine0_RPM { get; set; }
    public TelemetryValue<float> RFbrakeLinePress { get; set; }
    public TelemetryValue<float> RFcoldPressure { get; set; }
    public TelemetryValue<float> RFtempCL { get; set; }
    public TelemetryValue<float> RFtempCM { get; set; }
    public TelemetryValue<float> RFtempCR { get; set; }
    public TelemetryValue<float> RFwearL { get; set; }
    public TelemetryValue<float> RFwearM { get; set; }
    public TelemetryValue<float> RFwearR { get; set; }
    public TelemetryValue<float> LFbrakeLinePress { get; set; }
    public TelemetryValue<float> LFcoldPressure { get; set; }
    public TelemetryValue<float> LFtempCL { get; set; }
    public TelemetryValue<float> LFtempCM { get; set; }
    public TelemetryValue<float> LFtempCR { get; set; }
    public TelemetryValue<float> LFwearL { get; set; }
    public TelemetryValue<float> LFwearM { get; set; }
    public TelemetryValue<float> LFwearR { get; set; }
    public TelemetryValue<float> RRbrakeLinePress { get; set; }
    public TelemetryValue<float> RRcoldPressure { get; set; }
    public TelemetryValue<float> RRtempCL { get; set; }
    public TelemetryValue<float> RRtempCM { get; set; }
    public TelemetryValue<float> RRtempCR { get; set; }
    public TelemetryValue<float> RRwearL { get; set; }
    public TelemetryValue<float> RRwearM { get; set; }
    public TelemetryValue<float> RRwearR { get; set; }
    public TelemetryValue<float> LRbrakeLinePress { get; set; }
    public TelemetryValue<float> LRcoldPressure { get; set; }
    public TelemetryValue<float> LRtempCL { get; set; }
    public TelemetryValue<float> LRtempCM { get; set; }
    public TelemetryValue<float> LRtempCR { get; set; }
    public TelemetryValue<float> LRwearL { get; set; }
    public TelemetryValue<float> LRwearM { get; set; }
    public TelemetryValue<float> LRwearR { get; set; }
    public TelemetryValue<float> LRshockDefl { get; set; }
    public TelemetryValue<float> LRshockVel { get; set; }
    public TelemetryValue<float> RRshockDefl { get; set; }
    public TelemetryValue<float> RRshockVel { get; set; }
    public TelemetryValue<float> LFshockDefl { get; set; }
    public TelemetryValue<float> LFshockVel { get; set; }
    public TelemetryValue<float> RFshockDefl { get; set; }
    public TelemetryValue<float> RFshockVel { get; set; }
    public TelemetryValue<int[]> CarIdxLap { get; set; }
    public TelemetryValue<int[]> CarIdxLapCompleted { get; set; }
    public TelemetryValue<float[]> CarIdxLapDistPct { get; set; }
    public TelemetryValue<int[]> CarIdxTrackSurface { get; set; }
    public TelemetryValue<int[]> CarIdxTrackSurfaceMaterial { get; set; }
    public TelemetryValue<bool[]> CarIdxOnPitRoad { get; set; }
    public TelemetryValue<int[]> CarIdxPosition { get; set; }
    public TelemetryValue<int[]> CarIdxClassPosition { get; set; }
    public TelemetryValue<int[]> CarIdxClass { get; set; }
    public TelemetryValue<float[]> CarIdxF2Time { get; set; }
    public TelemetryValue<float[]> CarIdxEstTime { get; set; }
    public TelemetryValue<float[]> CarIdxLastLapTime { get; set; }
    public TelemetryValue<float[]> CarIdxBestLapTime { get; set; }
    public TelemetryValue<int[]> CarIdxBestLapNum { get; set; }
    public TelemetryValue<int[]> CarIdxTireCompound { get; set; }
    public TelemetryValue<int[]> CarIdxQualTireCompound { get; set; }
    public TelemetryValue<bool[]> CarIdxQualTireCompoundLocked { get; set; }
    public TelemetryValue<int[]> CarIdxFastRepairsUsed { get; set; }
    public TelemetryValue<int[]> CarIdxSessionFlags { get; set; }
    public TelemetryValue<int[]> CarIdxPaceLine { get; set; }
    public TelemetryValue<int[]> CarIdxPaceRow { get; set; }
    public TelemetryValue<int[]> CarIdxPaceFlags { get; set; }
    public TelemetryValue<float[]> CarIdxSteer { get; set; }
    public TelemetryValue<float[]> CarIdxRPM { get; set; }
    public TelemetryValue<int[]> CarIdxGear { get; set; }
    public TelemetryValue<bool[]> CarIdxP2P_Status { get; set; }
    public TelemetryValue<int[]> CarIdxP2P_Count { get; set; }
    public TelemetryValue<float[]> SteeringWheelTorque_ST { get; set; }
    public TelemetryValue<float[]> VelocityZ_ST { get; set; }
    public TelemetryValue<float[]> VelocityY_ST { get; set; }
    public TelemetryValue<float[]> VelocityX_ST { get; set; }
    public TelemetryValue<float[]> YawRate_ST { get; set; }
    public TelemetryValue<float[]> PitchRate_ST { get; set; }
    public TelemetryValue<float[]> RollRate_ST { get; set; }
    public TelemetryValue<float[]> VertAccel_ST { get; set; }
    public TelemetryValue<float[]> LatAccel_ST { get; set; }
    public TelemetryValue<float[]> LongAccel_ST { get; set; }
    public TelemetryValue<float[]> LRshockDefl_ST { get; set; }
    public TelemetryValue<float[]> LRshockVel_ST { get; set; }
    public TelemetryValue<float[]> RRshockDefl_ST { get; set; }
    public TelemetryValue<float[]> RRshockVel_ST { get; set; }
    public TelemetryValue<float[]> LFshockDefl_ST { get; set; }
    public TelemetryValue<float[]> LFshockVel_ST { get; set; }
    public TelemetryValue<float[]> RFshockDefl_ST { get; set; }
    public TelemetryValue<float[]> RFshockVel_ST { get; set; }
}