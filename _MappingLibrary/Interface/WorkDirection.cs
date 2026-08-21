using System;
using System.ComponentModel;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public enum WorkDirection
    {
        /// <summary>
        /// <para>°‹°Ê°Ê°Ê°Ê </para>
        /// <para>         °È</para>
        /// <para>°Á°Á°Á°Á°Á </para>
        /// <para>°È         </para>
        /// <para> °Ê°Ê°Ê°Ê°Ê</para>
        /// </summary>
        [Description("LT°ÊRIGHT S")]
        LT_RIGHT_S,

        /// <summary>
        /// <para>°Á-----°‹</para>
        /// <para>°È       </para>
        /// <para>-------°Ê</para>
        /// <para>       °È</para>
        /// <para>°Á-------</para>
        /// </summary>
        [Description("RT°ÊLEFT S")]
        RT_LEFT_S,

        /// <summary>
        /// 
        /// </summary>
        [Description("LT°ÊDOWN S")]
        LT_DOWN_S,

        /// <summary>
        /// 
        /// </summary>
        [Description("RT°ÊDOWN S")]
        RT_DOWN_S,

        /// <summary>
        /// <para> °Ê°Ê      </para>
        /// <para>°Ë  °È   °Ë</para>
        /// <para>°Ë  °È   °Ë</para>
        /// <para>°Ë  °È   °Ë</para>
        /// <para>°‹   °Ê°Ê  </para>
        /// </summary>
        [Description("LB°ÊUP S")]
        LB_UP_S,

        /// <summary>
        /// 
        /// </summary>
        [Description("RB°ÊUP S")]
        RB_UP_S,

        /// <summary>
        /// 
        /// </summary>
        [Description("LB°ÊRIGHT S")]
        LB_RIGHT_S,

        /// <summary>
        /// 
        /// </summary>
        [Description("RB°ÊLEFT S")]
        RB_LEFT_S,

        /// <summary>
        /// 
        /// </summary>
        [Description("LT°ÊRIGHT Z")]
        LT_RIGHT_Z,

        /// <summary>
        /// <para>°Á-----°‹</para>
        /// <para>°È       </para>
        /// <para>-------°Ê</para>
        /// <para>       °È</para>
        /// <para>°Á-------</para>
        /// </summary>
        [Description("RT°ÊLEFT Z")]
        RT_LEFT_Z,

        /// <summary>
        /// 
        /// </summary>
        [Description("LT°ÊDOWN Z")]
        LT_DOWN_Z,

        /// <summary>
        /// 
        /// </summary>
        [Description("RT°ÊDOWN Z")]
        RT_DOWN_Z,

        /// <summary>
        /// <para> °Ê°Ê      </para>
        /// <para>°Ë  °È   °Ë</para>
        /// <para>°Ë  °È   °Ë</para>
        /// <para>°Ë  °È   °Ë</para>
        /// <para>°‹   °Ê°Ê  </para>
        /// </summary>
        [Description("LB°ÊUP Z")]
        LB_UP_Z,

        /// <summary>
        /// 
        /// </summary>
        [Description("RB°ÊUP Z")]
        RB_UP_Z,

        /// <summary>
        /// 
        /// </summary>
        [Description("LB°ÊRIGHT Z")]
        LB_RIGHT_Z,

        /// <summary>
        /// 
        /// </summary>
        [Description("RB°ÊLEFT Z")]
        RB_LEFT_Z,
    }
}


