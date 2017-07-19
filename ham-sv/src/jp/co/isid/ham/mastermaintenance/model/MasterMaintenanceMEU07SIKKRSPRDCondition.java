package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 経理組織展開テーブル検索Condition
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/05/02 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceMEU07SIKKRSPRDCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索組織コードリスト */
    private List<String> _SIKCDList = null;

    /** 日付 */
    private String _HIDUKE = null;

    /**
     * 検索組織コードリストを取得します
     * @return _SIKCDList
     */
    public List<String> getSIKCDList()
    {
        return _SIKCDList;
    }

    /**
     * 検索組織コードリストを設定します
     * @param data セットする _SIKCDList
     */
    public void setSIKCDList(List<String> data)
    {
        _SIKCDList = data;
    }

    /**
     * 日付を取得する
     *
     * @return 日付
     */
    public String getHIDUKE()
    {
        return _HIDUKE;
    }

    /**
     * 日付を設定する
     *
     * @param val 日付
     */
    public void setHIDUKE(String val)
    {
        _HIDUKE = val;
    }

}
