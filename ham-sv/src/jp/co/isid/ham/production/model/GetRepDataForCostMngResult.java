package jp.co.isid.ham.production.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR�����@�N�����f�[�^�擾�̌��ʃN���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetRepDataForCostMngResult  extends AbstractServiceResult {

    /* =============================================================================================*/
    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B���擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
    /* =============================================================================================*/

    /** ���쌴���\�^�����\�̃w�b�_�p�f�[�^���X�g */
    private List<RepDataForCostMngHeaderVO> _repDataForCostMngHeader = null;
    /** ���쌴���\�^�����\�̖��חp�f�[�^���X�g */
    private List<RepDataForCostMngDetailsVO> _repDataForCostMngDetails = null;


    /**
     * ���쌴���\�^�����\�̃w�b�_�p�f�[�^���X�g���擾���܂�
     * @return
     */
    public List<RepDataForCostMngHeaderVO> getRepDataForCostMngHeader() {
        return _repDataForCostMngHeader;
    }

    /**
     * ���쌴���\�^�����\�̃w�b�_�p�f�[�^���X�g��ݒ肵�܂�
     * @param repDataForCostMngHeader
     */
    public void setRepDataForCostMngHeader(List<RepDataForCostMngHeaderVO> repDataForCostMngHeader) {
        _repDataForCostMngHeader = repDataForCostMngHeader;
    }

    /**
     * ���쌴���\�^�����\�̖��חp�f�[�^���X�g���擾���܂�
     * @return
     */
    public List<RepDataForCostMngDetailsVO> getRepDataForCostMngDetails() {
        return _repDataForCostMngDetails;
    }

    /**
     * ���쌴���\�^�����\�̖��חp�f�[�^���X�g��ݒ肵�܂�
     * @param repDataForCostMngDetails
     */
    public void setRepDataForCostMngDetails(List<RepDataForCostMngDetailsVO> repDataForCostMngDetails) {
        _repDataForCostMngDetails = repDataForCostMngDetails;
    }

}
