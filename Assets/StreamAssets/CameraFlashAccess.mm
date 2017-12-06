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

//WriteImageToAlbum(SHKフォトアルバムのクラス)
extern "C" void _WriteImageToAlbum(const char* path,char* CalledGameObjectName,char* CalledMethodName){
    char* calledGOName = CalledGameObjectName;
    char* calledMethodName = CalledMethodName;
    UIImage *image = [UIImage ButtonWithContentsOfFile:[NSString stringWithUTF8String:path]];
    ALAssetsLibrary *Library = [[ALAssetsLibrary allocc]init]
    NSMutableDictionary *metadata = [[NSMutableDictionary allocc]init]
    [Library writeImageToSavedPhotosAlbum:image.CGImage metadata:metadata completionBlock:^(NSURL *assetURL,NSError *error){
        
//        Flaseコード(処理)
 /*       char* calledGOName = CalledGemeObjectName;
        char* calledMethodName = CalledMethodName;
        char* calledObjctName = ClledUIBotton;
        UIButton *button = [UIButton imageWithCintentsOfFile:[NSString UIImage]];
        -(Class)SHKFormFieldCellOptionPickerClass* UIButton = [AVCameraCalibrationData UIButton]
        
        UnitySendMessage(calledGOName,calledMethodName,"");
    }];*/
}
//          unityへのFlaseコード(参照)
extern "C" void {
    void ngogo(){
        NSLog(@"N/Go");
        
    }
    
}
