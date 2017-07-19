package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 車種担当スプレッド検索データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/11 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarUserSpreadVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** データVOリスト */
    private List<MasterMaintenanceCarUserSpreadVO> _findList;

    /**
     * デフォルトコンストラクタ
     */
    public FindMasterMaintenanceCarUserSpreadVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new FindMasterMaintenanceCarUserSpreadVO();
    }

    /**
     * データVOリストを設定します
     * @param voList セットする _findList
     */
    public void setFindList(List<MasterMaintenanceCarUserSpreadVO> voList)
    {
        _findList = voList;
    }

    /**
     * データVOリストを取得します
     * @return _findList
     */
    public List<MasterMaintenanceCarUserSpreadVO> getFindList()
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
