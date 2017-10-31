//
//  Example.swift
//  NP_Unity
//
//  Created by yukio.miyamoto on 2017/10/12.
//  Copyright © 2017年 Yukio Miyamoto. All rights reserved.
//

import Foundation
import CoreMotion


    public class Example: NSObject {
        static let pedometer = CMPedometer()
    public static func swiftMethod(_CMPedometer: String){
        //UnitySendMessage("CallbackTarget","OnCallFromSwift","Hello,Unity!")

//        var pedometer = _CMPedometer
        
            // Do any additional setup after loading the view, typically from a nib.
        
            // CMPedometerの確認
            if(CMPedometer.isStepCountingAvailable()){
                
            pedometer.startUpdates(from: NSDate() as Date) {
                    (data: CMPedometerData?, error) -> Void in
                    DispatchQueue.main.async(execute: { () -> Void in
                        if(error == nil){
                            // 歩数
//                            let steps = data!.numberOfSteps
                        
                        }
                    })
                }
            }
        }
        
}
