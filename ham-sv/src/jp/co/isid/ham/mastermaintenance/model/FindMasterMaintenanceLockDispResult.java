package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �ߋ����b�N�\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/04 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceLockDispResult extends AbstractServiceResult
{
    /** �ߋ����b�N�����f�[�^VO */
    private FindMbj01SysStsVO _lockVO = null;

    /**
     * �ߋ����b�N�����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _lockVO
     */
    public void setLockVO(FindMbj01SysStsVO vo)
    {
        _lockVO = vo;
    }

    /**
     * �ߋ����b�N�����f�[�^VO���擾���܂�
     * @return _lockVO
     */
    public FindMbj01SysStsVO getLockVO()
    {
        return _lockVO;
    }

}
