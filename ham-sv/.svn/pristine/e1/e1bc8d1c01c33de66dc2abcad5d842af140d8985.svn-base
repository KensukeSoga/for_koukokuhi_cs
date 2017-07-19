package jp.co.isid.ham.media.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Tbj12Campaign;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * キャンペーンVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/22 HLC M.Tsuchiya)<BR>
 * </P>
 * @author HLC M.Tsuchiya
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindMediaPlanCampaignVO extends AbstractModel{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * キャンペーンNo＋キャンペーン名
     */
    private String _CODENAME = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindMediaPlanCampaignVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindMediaPlanCampaignVO();
    }

    /**
     * キャンペーンNoを取得する
     *
     * @return キャンペーンNo
     */
    public String getCAMPCD() {
        return (String) get(Tbj12Campaign.CAMPCD);
    }

    /**
     * キャンペーンNoを設定する
     *
     * @param val キャンペーンNo
     */
    public void setCAMPCD(String val) {
        set(Tbj12Campaign.CAMPCD, val);
    }

    /**
     * キャンペーン名を取得する
     *
     * @return キャンペーン名
     */
    public String getKENMEI() {
        return (String) get(Tbj12Campaign.CAMPNM);
    }

    /**
     * キャンペーン名を設定する
     *
     * @param val キャンペーン名
     */
    public void setKENMEI(String val) {
        set(Tbj12Campaign.CAMPNM, val);
    }

    /**
     * キャンペーンNo＋キャンペーン名を取得します
     * @return
     */
    public String getCODENAME() {
        return _CODENAME;
    }

    /**
     *キャンペーンNo＋キャンペーン名を設定します
     * @param val
     */
    public void setCODENAME(String val) {
        _CODENAME = val;
    }
}
