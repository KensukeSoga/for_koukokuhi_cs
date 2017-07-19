package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * セキュリティグループユーザー(HC/HM)検索データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHCHMSecGrpUserSpreadVO {

    private static final long serialVersionUID = 1L;

    /** データVOリスト */
    private List<MasterMaintenanceHCHMSecGrpUserSpreadVO> _findList;

    /**
     * デフォルトコンストラクタ
     */
    public FindMasterMaintenanceHCHMSecGrpUserSpreadVO()
    {
    }

    /**
     * データVOリストを設定します
     * @param voList セットする _findList
     */
    public void setFindList(List<MasterMaintenanceHCHMSecGrpUserSpreadVO> voList)
    {
        _findList = voList;
    }

    /**
     * データVOリストを取得します
     * @return _findList
     */
    public List<MasterMaintenanceHCHMSecGrpUserSpreadVO> getFindList()
    {
        return _findList;
    }

    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy)
    {
        _dummy = dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を取得します
     * @return String ダミープロパティ
     */
    public String getDummy()
    {
        return _dummy;
    }

}
