package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 新雑媒体マスタデータVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/11 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceMEU20MSMZBTVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 新雑区分 */
    private String _SZKBN           = null;

    /** 新雑媒体コード */
    private String _SINZATSUBTAICD  = null;

    /** 県版コード */
    private String _KBANCD          = null;

    /** 新雑媒体名（漢字） */
    private String _SINZATSUBTAINMJ = null;

    /** 新雑媒体名（カナ） */
    private String _SINZATSUBTAINMK = null;

    /**
     * デフォルトコンストラクタ
     */
    public MasterMaintenanceMEU20MSMZBTVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new MasterMaintenanceMEU20MSMZBTVO();
    }

    /**
     * 新雑区分を取得する
     *
     * @return 新雑区分
     */
    public String getSZKBN()
    {
        return _SZKBN;
    }

    /**
     * 新雑区分を設定する
     *
     * @param val 新雑区分
     */
    public void setSZKBN(String val)
    {
        _SZKBN = val;
    }

    /**
     * 新雑媒体コードを取得する
     *
     * @return 新雑媒体コード
     */
    public String getSINZATSUBTAICD()
    {
        return _SINZATSUBTAICD;
    }

    /**
     * 新雑媒体コードを設定する
     *
     * @param val 新雑媒体コード
     */
    public void setSINZATSUBTAICD(String val)
    {
        _SINZATSUBTAICD = val;
    }

    /**
     * 県版コードを取得する
     *
     * @return 県版コード
     */
    public String getKBANCD()
    {
        return _KBANCD;
    }

    /**
     * 県版コードを設定する
     *
     * @param val 県版コード
     */
    public void setKBANCD(String val)
    {
        _KBANCD = val;
    }

    /**
     * 新雑媒体名（漢字）を取得する
     *
     * @return 新雑媒体名（漢字）
     */
    public String getSINZATSUBTAINMJ()
    {
        return _SINZATSUBTAINMJ;
    }

    /**
     * 新雑媒体名（漢字）を設定する
     *
     * @param val 新雑媒体名（漢字）
     */
    public void setSINZATSUBTAINMJ(String val)
    {
        _SINZATSUBTAINMJ = val;
    }

    /**
     * 新雑媒体名（カナ）を取得する
     *
     * @return 新雑媒体名（カナ）
     */
    public String getSINZATSUBTAINMK()
    {
        return _SINZATSUBTAINMK;
    }

    /**
     * 新雑媒体名（カナ）を設定する
     *
     * @param val 新雑媒体名（カナ）
     */
    public void setSINZATSUBTAINMK(String val)
    {
        _SINZATSUBTAINMK = val;
    }


}
