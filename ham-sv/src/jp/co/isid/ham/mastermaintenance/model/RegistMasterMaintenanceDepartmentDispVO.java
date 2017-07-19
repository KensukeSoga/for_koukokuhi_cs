package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 部署表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/11 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceDepartmentDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 部署登録データVO */
    private RegistMbj32DepartmentVO _departmentVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceDepartmentDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceDepartmentDispVO();
    }

    /**
     * 部署登録データVOを設定します
     * @param vo セットする _departmentVO
     */
    public void setDepartmentVO(RegistMbj32DepartmentVO vo)
    {
        _departmentVO = vo;
    }

    /**
     * 部署登録データVOを取得します
     * @return _departmentVO
     */
    public RegistMbj32DepartmentVO getDepartmentVO()
    {
        return _departmentVO;
    }

}
