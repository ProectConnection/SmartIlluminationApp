//
//  CameraRollAccess.m
//  photoAccessForUnity
//
//  Created by macH28-15 on 2017/10/16.
//  Copyright © 2017年 macH28-15. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <AssetsLibrary/AssetsLibrary.h>
#import <AVFoundation/AVFoundation.h>

extern "C" void _WriteImageToAlbum(const char* path,char* CalledGameObjectName,char* CalledMethodName){
    char* calledGOName = CalledGameObjectName;
    char* calledMethodName = CalledMethodName;
    UIImage *image = [UIImage imageWithContentsOfFile:[NSString stringWithUTF8String:path]];
    ALAssetsLibrary *Library = [[ALAssetsLibrary alloc]init];
    NSMutableDictionary *metadata = [[NSMutableDictionary alloc]init];
    [Library writeImageToSavedPhotosAlbum:image.CGImage metadata:metadata completionBlock:^(NSURL *assetURL,NSError *error){
        
        UnitySendMessage(calledGOName,calledMethodName,"");
    }];
}

extern "C" void _PlaySystemShutterSound(){
    AudioServicesPlaySystemSound(1108);
}
