package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * MasterForm検索データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMasterFormVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 機能制御情報VOリスト */
    private List<FunctionControlInfoVO> _findFunctionControlInfoList;

    /** セキュリティ情報VOリスト */
    private List<SecurityInfoVO> _findSecurityInfoList;

    /**
     * デフォルトコンストラクタ
     */
    public FindMasterMaintenanceMasterFormVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new FindMasterMaintenanceMasterFormVO();
    }

    /**
     * 機能制御情報VOリストを設定します
     * @param voList セットする _findFunctionControlInfoList
     */
    public void setFindFunctionControlInfoList(List<FunctionControlInfoVO> voList)
    {
        _findFunctionControlInfoList = voList;
    }

    /**
     * 機能制御情報VOリストを取得します
     * @return _findFunctionControlInfoList
     */
    public List<FunctionControlInfoVO> getFindFunctionControlInfoList()
    {
        return _findFunctionControlInfoList;
    }

    /**
     * セキュリティ情報VOリストを設定します
     * @param voList セットする _findSecurityInfoList
     */
    public void setFindSecurityInfoList(List<SecurityInfoVO> voList)
    {
        _findSecurityInfoList = voList;
    }

    /**
     * セキュリティ情報VOリストを取得します
     * @return _findSecurityInfoList
     */
    public List<SecurityInfoVO> getFindSecurityInfoList()
    {
        return _findSecurityInfoList;
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
