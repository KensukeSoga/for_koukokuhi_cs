package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �Ԏ�S���\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarUserDispResult extends AbstractServiceResult
{
    /** �Ԏ�S���X�v���b�h�����f�[�^VO */
    private FindMasterMaintenanceCarUserSpreadVO _carUserSpreadVO = null;

    /**
     * �Ԏ�S���X�v���b�h�����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _carUserSpreadVO
     */
    public void setCarUserSpreadVO(FindMasterMaintenanceCarUserSpreadVO vo)
    {
        _carUserSpreadVO = vo;
    }

    /**
     * �Ԏ�S���X�v���b�h�����f�[�^VO���擾���܂�
     * @return _carUserSpreadVO
     */
    public FindMasterMaintenanceCarUserSpreadVO getCarUserSpreadVO()
    {
        return _carUserSpreadVO;
    }

}
