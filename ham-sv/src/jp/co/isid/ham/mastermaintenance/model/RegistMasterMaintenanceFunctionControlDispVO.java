package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 機能制御表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceFunctionControlDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 機能制御登録データVO */
    private RegistMbj33FunctionControlVO _functionControlVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceFunctionControlDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceFunctionControlDispVO();
    }

    /**
     * 機能制御登録データVOを設定します
     * @param vo セットする _functionControlVO
     */
    public void setFunctionControlVO(RegistMbj33FunctionControlVO vo)
    {
        _functionControlVO = vo;
    }

    /**
     * 機能制御登録データVOを取得します
     * @return _functionControlVO
     */
    public RegistMbj33FunctionControlVO getFunctionControlVO()
    {
        return _functionControlVO;
    }

}
