/**********************************************************************************
 *  Copyright (c) CyberRidge Software (P) Ltd.
 *
 *  All rights reserved. This software and its documentation are confidential and
 *  proprietary to CyberRidge Software (P) Ltd. No part of the software or its
 *  documentation may be reproduced, modified, or disclosed without prior written
 *  consent from CyberRidge Software (P) Ltd.
 *
 *  CyberRidge Software (P) Ltd. retains all intellectual property rights to the
 *  code and any derivative works thereof. Unauthorized copying or reproduction
 *  of this code or any part thereof is strictly prohibited.
 *
 *  This software is provided "as is" without warranty of any kind, express or
 *  implied, including, but not limited to, the implied warranties of
 *  merchantability, fitness for a particular purpose, or non-infringement.
 *
 *  CyberRidge Software (P) Ltd. reserves the right to make changes to the software
 *  or its documentation at any time without notice.
 *
 *  This notice may not be removed or altered from any source distribution.
 **********************************************************************************/

namespace CyberRidgeSoftware.IdentityHub.Sdk.WebAPI
{
    public class IDHApiResponse<T>
    {
        public T Data { get; set; }
    }

    public class IDHApiResponseArray<T>
    {
        public int TotalCount { get; set; }
        public T[] Data { get; set; }
    }
}
