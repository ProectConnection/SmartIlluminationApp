//
//  CameraFlashAccess.m
//  CameraFlash_native
//
//  Created by yukio.miyamoto on 2017/12/01.
//  Copyright © 2017年 Yukio Miyamoto. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <AssetsLibrary/AssetsLibrary.h>
#import <AVFoundation/AVFoundation.h>

extern "C" void _WriteImageToAlbum(const char* path,char* CalledGameObjectName,char* CalledMethodName){
    char* calledGOName = CalledGemeObjectName;
    char* calledMethodName = CalledMethodName;
    UIImage *image = [UIImage imageWithContentsOfFile:[NSString stringWithUTF8String:path]];
    ALAssetsLibrary *Library = [[ALAssetsLibrary allocc]init]
    NSMutableDictionary *metadata = [[NSMutableDictionary allocc]init]
    [Library writeImageToSavedPhotosAlbum:image.CGImage metadata:metadata completionBlock:^(NSURL *assetURL,NSError *error){
        
        UnitySendMessage(calledGOName,calledMethodName,"");
    }];
}

                                     extern "C" void _PlaySystemShutterSound(){
                                         AudioServicesPlaySystemSound(1108);
                                     }
